import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

import { AppUtils } from '../../../helpers';
import { InvoiceDetailModel, ItemListItemModel } from '../../../models';
import { InvoiceService, ItemService } from '../../../services';

@Component({
    selector: 'app-invoice-detail',
    templateUrl: './invoice.detail.component.html'
})

export class InvoiceDetailComponent implements OnInit {
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    multiSelectDropdownConfigs: IDropdownSettings;
    model: InvoiceDetailModel = new InvoiceDetailModel();
    items: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();

    constructor(private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private invoiceService: InvoiceService,
        private itemService: ItemService) {
        this.route.params.subscribe((params) => {
            this.model.id = params['id'];
        });
    }

    ngOnInit() {
        this.loadItems();
        this.loadInvoice();
    }

    loadInvoice() {
        this.blockUI.start();
        this.invoiceService.getDetail(this.model.id).subscribe(
            (data: any) => {
                this.blockUI.stop();
                Object.assign(this.model, data);
                this.model.createdOn = this.appUtils.getFormattedDate(this.model.createdOn, null);
                this.updateSelectedItems();
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

    loadItems() {
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
        this.model.amount = 0;
        this.model.items.map((invoiceItem) => {
            const item = this.items.find(x => x.id === invoiceItem.id);
            if (item) {
                item.rate = invoiceItem.rate;
                tempArray.push(item);
                this.model.amount += item.rate;
            }
        });

        this.selectedItems = tempArray;
    }


    delete(): void {
        if (!confirm('Are you sure you want to delete the selected invoice?')) {
            return;
        }
        this.blockUI.start();
        this.invoiceService.delete(this.model.id).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['/invoice/manage']);
                }, 100);
                setTimeout(() => {
                    this.toastr.success('Invoice has been deleted successfully.');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

    print() {
        window.open(location.origin + '/print/invoice/' + this.model.id);
    }

}
