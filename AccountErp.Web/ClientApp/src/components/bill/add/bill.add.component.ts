import { Component, OnInit } from '@angular/core';
import { HttpEvent, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { AppUtils } from '../../../helpers';
import {
    BillAddModel, AttachmentAddModel, SelectListItemModel, ItemListItemModel,
    VendorPersonalInfoModel
} from '../../../models';
import { BillService, VendorService } from '../../../services';

@Component({
    selector: 'app-bill-add',
    templateUrl: './bill.add.component.html'
})

export class BillAddComponent implements OnInit {
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    modalReference: any;
    model: BillAddModel = new BillAddModel();
    vendor: VendorPersonalInfoModel = new VendorPersonalInfoModel();
    vendors: Array<SelectListItemModel> = new Array<SelectListItemModel>();
    selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();

    constructor(private router: Router,
        private route: ActivatedRoute,
        private modalService: NgbModal,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private billService: BillService,
        private vendorService: VendorService) {

    }

    ngOnInit() {
        this.loadVendors();

        if (!this.model.attachments || this.model.attachments.length === 0) {
            const attachmentFile = new AttachmentAddModel();
            this.model.attachments.push(attachmentFile);
        }
    }

    loadVendors() {
        this.blockUI.start();
        this.vendorService.getSelectItems()
            .subscribe((data) => {
                this.blockUI.stop();
                Object.assign(this.vendors, data);
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    onVendorSelected() {
        this.getVendorDetail();
    }

    getVendorDetail() {
        this.blockUI.start();
        this.vendor = new VendorPersonalInfoModel();
        this.vendorService.getPersonalInfo(Number(this.model.vendorId))
            .subscribe(
                (data) => {
                    this.blockUI.stop();
                    Object.assign(this.vendor, data);
                },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                }
            );
    }

    addNewAttachment() {
        let flag: Boolean = true;
        this.model.attachments.map((item) => {
            if (!item.fileName) {
                flag = false;
            }
        });

        if (!flag) {
            this.toastr.error('Please upload file to continue');
            return;
        }

        const attachmentFile = new AttachmentAddModel();
        this.model.attachments.push(attachmentFile);
    }

    onSelectFile(event: any, index: number) {
        if (!event.target.files
            || event.target.files.length === 0) {
            return;
        }

        const attachmentFile = this.model.attachments[this.model.attachments.length - 1];

        attachmentFile.originalFileName = event.target.files[0].name;

        if (!attachmentFile.title) {
            attachmentFile.title = attachmentFile.originalFileName;
        }
        const file = event.target.files.item(0);
        this.uploadAttachment(file, attachmentFile);
    }

    uploadAttachment(file: any, attachment: AttachmentAddModel) {
        this.billService.uploadAttachmentFile(file)
            .subscribe(
                (event: HttpEvent<any>) => {
                    switch (event.type) {
                        case HttpEventType.UploadProgress:
                            const percentDone = Math.round(100 * event.loaded / event.total);
                            attachment.uploadedPercent = percentDone;
                            break;
                        case HttpEventType.Response:
                            attachment.fileName = event.body.fileName;
                            attachment.originalFileName = file.name;
                            break;
                        default:
                            console.log(`File "${file.name}" surprising upload event: ${event.type}.`);
                    }
                },
                (error) => {
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    removeAttachment(file: AttachmentAddModel) {
        if (this.model.attachments.length === 1) {
            this.model.attachments[0] = new AttachmentAddModel();
            return;
        }
        const itemIndex = this.model.attachments.indexOf(file);
        this.model.attachments.splice(itemIndex, 1);
    }

    deleteItem(index: number) {
        this.selectedItems.splice(index, 1);
        this.updateTotalAmount();
    }

    updateTotalAmount() {
        this.model.totalAmount = 0;
        this.model.tax = 0;
        this.selectedItems.map((item: ItemListItemModel) => {
            if (item.taxPercentage != null) {
                this.model.tax += (item.rate * item.taxPercentage) / 100;
            }
            this.model.totalAmount += item.rate;
        });

        if (this.vendor.discount != null) {
            this.model.discount = this.model.totalAmount * this.vendor.discount / 100;
            this.model.totalAmount -= this.model.discount;
        }


        this.model.totalAmount = this.model.totalAmount + this.model.tax;
        this.model.totalAmount = Math.round(this.model.totalAmount * 100) / 100;
    }

    openItemsModal(content: any) {
        this.modalReference = this.modalService.open(content,
            {
                backdrop: 'static',
                keyboard: false,
                size: 'lg'
            });
    }

    closeItemsModal() {
        this.updateTotalAmount();
        this.modalReference.close();
    }

    submit() {
        if (this.selectedItems.length > 0) {
            this.selectedItems.map((item) => {
                this.model.items.push(item.id);
            });
        } else {
            this.toastr.error('Please select items/services to continue');
            return;
        }

        if (this.model.attachments.length === 1) {
            const attachment = this.model.attachments[0];
            if (!attachment.fileName) {
                this.model.attachments = new Array<AttachmentAddModel>();
            }
        }

        this.blockUI.start();

        this.billService.add(this.model).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['/bill/manage']);
                }, 100);

                setTimeout(() => {
                    this.toastr.success('Bill & expense has been added successfully');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }
}