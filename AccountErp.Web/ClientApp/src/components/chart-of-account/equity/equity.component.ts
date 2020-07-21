import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppUtils } from 'src/helpers';
import { ChartOfAccountsService } from 'src/services/chart-of-accounts.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'app-equity',
  templateUrl: './equity.component.html',
  styleUrls: ['./equity.component.css']
})
export class EquityComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  accountList;
  constructor(
    router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService,
        private appUtils: AppUtils,
    private chartofaccService:ChartOfAccountsService
  ) { }

  ngOnInit() {
  //      this.blockUI.start();
  //   this.chartofaccService.getAssetAccounts().subscribe(
  //       (data: any) => {
  //           this.blockUI.stop();
  //           Object.assign(this.accountList, data);
            
  //       },
  //       error => {
  //           this.blockUI.stop();
  //           this.appUtils.ProcessErrorResponse(this.toastr, error);
  //       });
   }

}
