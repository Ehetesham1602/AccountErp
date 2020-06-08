import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { AppUtils } from '../../../helpers';
import { ItemListItemModel, BillDetailModel } from '../../../models';
import { ItemService, BillService } from '../../../services';

@Component({
    selector: 'app-bill-detail',
    templateUrl: './bill.detail.component.html'
})

export class BillDetailComponent implements OnInit {
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    model: BillDetailModel = new BillDetailModel();
    items: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    isModelLoaded = false;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private billService: BillService,
        private itemService: ItemService) {
        this.route.params.subscribe((params) => {
            this.model.id = params['id'];
        });
    }

    ngOnInit() {
        this.loadServices();
        this.loadBill();
    }

    loadBill() {
        this.blockUI.start();
        this.billService.getDetail(this.model.id).subscribe(
            (data: any) => {
                this.blockUI.stop();
                Object.assign(this.model, data);
                this.updateSelectedItems();
                if (this.model.dueDate) {
                    this.model.dueDate = this.appUtils.getFormattedDate(this.model.dueDate, null);
                }
                this.isModelLoaded = true;
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

    loadServices() {
        this.itemService.getAllActiveOnly()
            .subscribe((data: any) => {
                if (!data || data.length === 0) {
                    return;
                }

                this.items = data;

                this.updateSelectedItems();
            },
                error => {
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    updateSelectedItems() {
        if (this.items.length === 0 || this.model.items.length === 0) {
            return;
        }

        const tempArray = new Array<ItemListItemModel>();

        this.model.items.map((serviceId) => {
            const service = this.items.find(x => x.id === serviceId);
            if (service) {
                tempArray.push(service);
            }
        });

        this.selectedItems = tempArray;
    }


    delete(): void {
        if (!confirm('Are you sure you want to delete the selected bill?')) {
            return;
        }
        this.blockUI.start();
        this.billService.delete(this.model.id).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['/bill/manage']);
                }, 100);
                setTimeout(() => {
                    this.toastr.success('Bill has been deleted successfully');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

    print() {
        let params = `scrollbars=no,resizable=no,status=no,location=no,toolbar=no,menubar=no,width=0,height=0,left=-1000,top=-1000`;
        window.open(location.origin + '/print/bill/' + this.model.id, params);
    }
}

