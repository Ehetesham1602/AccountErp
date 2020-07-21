import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { SelectListItemModel, BillPaymentModel, VendorPaymentInfoModel, ExpenseSummaryModel } from 'src/models';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppUtils } from 'src/helpers';
import { BankAccountService,BillService, VendorService, BillPaymentService, CreditCardService } from 'src/services';

@Component({
  selector: 'app-add-vendor-payment',
  templateUrl: './add-vendor-payment.component.html',
  styleUrls: ['./add-vendor-payment.component.css']
})
export class AddVendorPaymentComponent implements OnInit {
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  model: BillPaymentModel = new BillPaymentModel();
  paymentModes: Array<SelectListItemModel> = new Array<SelectListItemModel>();
  bankAccounts: Array<SelectListItemModel> = new Array<SelectListItemModel>();
  creditCards: Array<SelectListItemModel> = new Array<SelectListItemModel>();
  depositToAccounts: Array<SelectListItemModel> = new Array<SelectListItemModel>();
  vendorPaymentInfoModel: VendorPaymentInfoModel = new VendorPaymentInfoModel();
  expenseSummaryModel: ExpenseSummaryModel = new ExpenseSummaryModel();
  vendors=[];

  constructor(private router: Router,
      private route: ActivatedRoute,
      private toastr: ToastrService,
      private appUtils: AppUtils,
      private billService: BillService,
      private bankAccountService: BankAccountService,
      private vendorService: VendorService,
      private billPaymentService: BillPaymentService,
      private creditCardService: CreditCardService) {
      this.route.params.subscribe((params) => {
          this.model.billId = params['id'];
      });
  }

  ngOnInit() {
      this.paymentModes = this.appUtils.getPaymentModesSelectList();
      this.loadBankAccounts();
      this.loadCreditCards();
      this.loadExpenseSummary();
      this.model.paymentDate = this.appUtils.getDateForNgDatePicker(null);
      this.loadVendors();
  }

  loadBankAccounts() {
      this.bankAccountService.getSelectItems()
          .subscribe(
              data => {
                  Object.assign(this.bankAccounts, data);
              },
              error => {
                  this.appUtils.ProcessErrorResponse(this.toastr, error);
              });
  }

  loadCreditCards() {
      this.creditCardService.getSelectItems()
          .subscribe(
              data => {
                  Object.assign(this.creditCards, data);
              },
              error => {
                  this.appUtils.ProcessErrorResponse(this.toastr, error);
              });
  }

  loadExpenseSummary() {
      this.blockUI.start();
      this.billService.getSummary(this.model.billId)
          .subscribe(
              (data) => {
                  this.blockUI.stop();
                  Object.assign(this.expenseSummaryModel, data);
                  setTimeout(() => {
                      this.loadVendorPaymentInfo();
                  }, 100);
              },
              error => {
                  this.blockUI.stop();
                  this.appUtils.ProcessErrorResponse(this.toastr, error);
              });
  }

  loadVendorPaymentInfo() {
      this.blockUI.start();
      this.vendorService.getPaymentInfo(this.expenseSummaryModel.vendorId)
          .subscribe(
              data => {
                  this.blockUI.stop();
                  Object.assign(this.vendorPaymentInfoModel, data);

                  if (this.vendorPaymentInfoModel.accountNumber != null) {
                      const selectListItem = new SelectListItemModel();
                      selectListItem.keyString = this.vendorPaymentInfoModel.accountNumber;
                      selectListItem.value = this.vendorPaymentInfoModel.accountNumber;
                      this.depositToAccounts.push(selectListItem);
                  }
              },
              error => {
                  this.blockUI.stop();
                  this.appUtils.ProcessErrorResponse(this.toastr, error);
              });
  }

  chengePaymentMode() {
      if (this.model.paymentMode !== '2') {
          this.model.chequeNumber = '';
      }

      if (this.model.paymentMode == '0') {
        //     this.chartofaccService.getaccbyledgertype()
        //     .subscribe(
        //         data => {
        //             Object.assign(this.bankAccounts, data);
        //         },
        //         error => {
        //             this.appUtils.ProcessErrorResponse(this.toastr, error);
        //         });
        this.bankAccounts=[{keyInt:1,keyString:"",value:"Cash on hand"},{keyInt:2,keyString:"",value:"Petty cash"}]

         }
  }

  loadVendors() {
    this.blockUI.start();
    this.vendorService.getSelectItems()
        .subscribe((data) => {
            this.blockUI.stop();
            this.vendors=[];
            Object.assign(this.vendors, data);
            console.log("vendr",this.vendors);
        },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
}


  submit() {
      this.blockUI.start();
      if (this.model.paymentDate) {
          this.model.paymentDate = this.appUtils.getFormattedDate(this.model.paymentDate, null);
      }
      this.billPaymentService.add(this.model)
          .subscribe(
              data => {
                  this.blockUI.stop();
                  setTimeout(() => {
                      this.router.navigate(['/bill/payments']);
                  }, 100);
                  setTimeout(() => {
                      this.toastr.success('Payment has been done successfully');
                  }, 500);
              },
              error => {
                  this.blockUI.stop();
                  this.appUtils.ProcessErrorResponse(this.toastr, error);
              });
  }
}
