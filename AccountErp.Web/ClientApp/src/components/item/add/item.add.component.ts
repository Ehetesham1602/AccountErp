import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { AppUtils } from '../../../helpers';
import { ItemAddModel, SelectListItemModel } from '../../../models'
import { ItemService, MasterDataService, SalesTaxService } from '../../../services';

@Component({
    selector: 'app-item-add',
    templateUrl: './item.add.component.html'
})

export class ItemAddComponent implements OnInit {
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    model: ItemAddModel = new ItemAddModel();

    itemType: Array<SelectListItemModel> = new Array<SelectListItemModel>();
    salesTaxes: Array<SelectListItemModel> = new Array<SelectListItemModel>();

    constructor(private router: Router,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private itemService: ItemService,
        private salesTaxSerivce : SalesTaxService,
        private masterDataService: MasterDataService) {
    }

    ngOnInit() {
        this.loadItemType();
        this.loadSalesTax();
    }

    loadItemType() {
        this.blockUI.start();
        this.masterDataService.getItemType()
            .subscribe((data) => {
                this.blockUI.stop();
                Object.assign(this.itemType, data);
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    loadSalesTax() {
        this.blockUI.start();
        this.salesTaxSerivce.getSelectListItems()
            .subscribe((data) => {
                this.blockUI.stop();
                Object.assign(this.salesTaxes, data);
                console.log("taxlist",this.salesTaxes)
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    submit() {
        this.blockUI.start();
        this.itemService.add(this.model).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['item/manage']);
                }, 100);
                setTimeout(() => {
                    this.toastr.success('Item & service has been added successfully');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }
}