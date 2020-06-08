import { Component, OnInit } from '@angular/core';
import { HttpEvent, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { AppUtils } from '../../../helpers';
import {
    SelectListItemModel, InvoiceAddModel, AttachmentAddModel, ItemListItemModel, CustomerDetailModel
} from '../../../models';
import { InvoiceService, CustomerService, ItemService } from '../../../services';

@Component({
    selector: 'app-invoice-add',
    templateUrl: './invoice.add.component.html'
})

export class InvoiceAddComponent implements OnInit {
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    modalReference: any;
    disableCustomerId = false;
    model: InvoiceAddModel = new InvoiceAddModel();
    customer: CustomerDetailModel = new CustomerDetailModel();
    customers: Array<SelectListItemModel> = new Array<SelectListItemModel>();
    Items: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();

    constructor(private router: Router,
        private route: ActivatedRoute,
        private modalService: NgbModal,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private invoiceService: InvoiceService,
        private customerService: CustomerService,
        private itemService: ItemService) {

        this.route.queryParams.subscribe((params) => {
            if (params['cId']) {
                this.model.customerId = params['cId'];
                this.disableCustomerId = true;
                this.getCustomerDetail();
            }
        });
    }

    ngOnInit() {

        this.loadCustomers();

        this.loadItems();

        if (!this.model.attachments || this.model.attachments.length === 0) {
            const attachmentFile = new AttachmentAddModel();
            this.model.attachments.push(attachmentFile);
        }
    }

    loadCustomers() {
        this.blockUI.start();
        this.customerService.getSelectItems()
            .subscribe((data) => {
                this.blockUI.stop();
                Object.assign(this.customers, data);
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    loadItems() {
        this.blockUI.start();
        this.itemService.getAllActiveOnly()
            .subscribe((data: any) => {
                this.blockUI.stop();
                if (!data || data.length === 0) {
                    return;
                }
                this.Items = data;
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    deleteItem(index: number) {
        this.selectedItems.splice(index, 1);
        this.updateTotalAmount();
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
        this.invoiceService.uploadAttachmentFile(file)
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

    removeAttachment(documentFile: AttachmentAddModel) {
        if (this.model.attachments.length === 1) {
            this.model.attachments[0] = new AttachmentAddModel();
            return;
        }
        const itemIndex = this.model.attachments.indexOf(documentFile);
        this.model.attachments.splice(itemIndex, 1);
    }

    getCustomerDetail() {
        if (this.model.customerId === null
            || this.model.customerId === '') {
            this.model.phone = '';
            this.model.email = '';
            this.model.invoiceNumber = '';
            this.model.discount = 0;
            return;
        }

        this.customerService.getDetail(Number(this.model.customerId))
            .subscribe(
                (data) => {
                    Object.assign(this.customer, data);
                    this.model.phone = this.customer.phone;
                    this.model.email = this.customer.email;

                    if (!this.customer.discount) {
                        this.customer.discount = 0;
                    }

                    this.updateTotalAmount();
                });

    }

    onItemSelectionDone() {
        if (this.selectedItems.length > 0) {
            this.updateTotalAmount();
        } else {
            this.model.totalAmount = null;
        }
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

        if (this.customer.discount != null) {
            this.model.discount = this.model.totalAmount * this.customer.discount / 100;
            this.model.totalAmount -= this.model.discount;
        }


        this.model.totalAmount = this.model.totalAmount + this.model.tax;
        this.model.totalAmount = Math.round(this.model.totalAmount * 100) / 100;
    }

    openItemesModal(content: any) {
        this.modalReference = this.modalService.open(content,
            {
                backdrop: 'static',
                keyboard: false,
                size: 'lg'
            });
    }

    closeItemesModal() {
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

        this.invoiceService.add(this.model).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['/invoice/manage']);
                }, 100);
                setTimeout(() => {
                    this.toastr.success('Invoice has been added successfully');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }
}
