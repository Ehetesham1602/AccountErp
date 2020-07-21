import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ChartOfAccountsService } from 'src/services/chart-of-accounts.service';
import { AppUtils } from '../../../helpers';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-assets',
  templateUrl: './assets.component.html',
  styleUrls: ['./assets.component.css']
})
export class AssetsComponent implements OnInit {
  @Output() openAddAccountModal = new EventEmitter();
  @Output() closeAddAccountModal = new EventEmitter();
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  accType;
  accountList;
  constructor(
    private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService,
        private appUtils: AppUtils,
    private chartofaccService:ChartOfAccountsService) { }

  ngOnInit() {
    // this.blockUI.start();
    // this.chartofaccService.getAssetAccounts().subscribe(
    //     (data: any) => {
    //         this.blockUI.stop();
    //         Object.assign(this.accountList, data);
            
    //     },
    //     error => {
    //         this.blockUI.stop();
    //         this.appUtils.ProcessErrorResponse(this.toastr, error);
    //     });
}

}
