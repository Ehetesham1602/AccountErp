import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { SalesTaxAddModel } from 'src/models';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppUtils } from 'src/helpers';
import { SalesTaxService } from 'src/services';
import { chartOfAccountsList } from '../chartOfAccountsList';

@Component({
  selector: 'app-add-new-account',
  templateUrl: './add-new-account.component.html',
  styleUrls: ['./add-new-account.component.css']
})
export class AddNewAccountComponent implements OnInit {
  @BlockUI('container-blockui') blockUI: NgBlockUI;
    model: SalesTaxAddModel = new SalesTaxAddModel();
    @Output() closeAddAccountModal = new EventEmitter();
    @Input() accType:string;
    acctypeList;
    constructor(private router: Router,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private accountList:chartOfAccountsList,
        private salesTaxService: SalesTaxService) {
          
    }

    ngOnInit() {
      debugger;
     if(this.accType=="assets"){
     this.acctypeList=this.accountList.assets;
     }
    }

    submit() {
      debugger;
        this.blockUI.start();
        this.salesTaxService.add(this.model).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['/sales-tax/manage']);
                }, 100);
                setTimeout(() => {
                    this.toastr.success('Sales Tax has been added successfully');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

}
