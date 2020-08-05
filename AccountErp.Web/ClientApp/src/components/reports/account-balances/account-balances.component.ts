import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AppUtils, AppSettings } from 'src/helpers';
import { AccountBalanceService } from 'src/services/account.balance.service';
import { AccountBalanceDetail } from 'src/models/accountBalance/accountBalance.model';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-account-balances',
  templateUrl: './account-balances.component.html',
  styleUrls: ['./account-balances.component.css']
})
export class AccountBalancesComponent implements OnInit {

  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;

  accountBalanceData={totalAmount:0,totalUnpaidAmount:0,totalNotYetOverDue:0,totalCountNotYetOverDue:0,
    totalLessThan30:0,totalCountLessThan30 :0,totalCountThirtyFirstToSixty:0,
    totalThirtyFirstToSixty:0,totalSixtyOneToNinety:0,totalCountSixtyOneToNinety:0,
    totalMoreThanNinety:0,totalCountMoreThanNinety:0,agedPayablesReportDtoList:[{}]};
  model: AccountBalanceDetail = new AccountBalanceDetail();
  selectedstType = 'accural';
  startDate;
  endDate;
  fromDate;
  toDate;
  asOfDate;
  today = new Date();
  allStartingBalance;
  allCreditBalance;
  allDebitBalance;
  allNetMovementBalance;
  allEndingBalance;

  allStartingBalanceLiabilites;
  allDebitLiabilites;
  allCreditLiabilites;
  allNetMovementLiabilites;
  allEndingLiabilites;

  allStartingBalanceEquity;
  allDebitEquity;
  allCreditEquity;
  allNetMovementEquity;
  allEndingEquity;

  allDebitIncome;
  allCreditIncome;
  allNetMovementIncome;

   allDebitExpense;
   allCreditExpense;
   allNetMovementExpense;

   allDebitExpTotal;
   allCreditExpTotal;

  temp;

  constructor(private appSettings: AppSettings,
    private accountBalanceService: AccountBalanceService,
    private toastr: ToastrService,
        private appUtils: AppUtils) { }

  ngOnInit() {
  }

  showAccountBalance() {
    // this.purchaseVendortData = {vendorReportsList={}};
    console.log("from",this.fromDate);
    console.log("from",this.toDate);
    // if (this.selectedVendor !== undefined) {
     debugger;
     var body={ 
      "vendorId": 0,
      //  "vendorId": this.selectedVendor.keyInt,
     "vendorName": "string",
    //  "startDate":  this.fromDate,
    //  "endDate": this.toDate,
    //  "totalPaidAmount": 0,
    //  "totalAmount": 0,
    //  "status": "string"
    //  "vendorId": 0,
     "asOfDate": "2020-07-21T06:21:14.033Z"};
     
 
     this.accountBalanceService.getAccountBalance(body)
     .subscribe(
         (data) => {
           debugger
           console.log("statement",data);
          // Object.assign(this.temp, data);
              Object.assign(this.accountBalanceData, data);
              this.allStartingBalance=this.accountBalanceData.totalAmount;
              this.allCreditBalance=this.accountBalanceData.totalUnpaidAmount;
              this.allDebitBalance=this.accountBalanceData.totalNotYetOverDue;
              this.allNetMovementBalance=this.accountBalanceData.totalCountNotYetOverDue;
              this.allEndingBalance=this.accountBalanceData.totalLessThan30;

              this.allStartingBalanceLiabilites=this.accountBalanceData.totalCountLessThan30;
              this.allDebitLiabilites=this.accountBalanceData.totalThirtyFirstToSixty;
              this.allCreditLiabilites=this.accountBalanceData.totalCountThirtyFirstToSixty;
              this.allNetMovementLiabilites=this.accountBalanceData.totalSixtyOneToNinety;
              this.allEndingLiabilites=this.accountBalanceData.totalCountSixtyOneToNinety;

              this.allStartingBalanceEquity=this.accountBalanceData.totalMoreThanNinety;
              this.allDebitEquity=this.accountBalanceData.totalCountMoreThanNinety;
              this.allCreditEquity=this.accountBalanceData.totalUnpaidAmount;
              this.allNetMovementEquity=this.accountBalanceData.totalAmount;
              this.allEndingEquity=this.accountBalanceData.totalCountSixtyOneToNinety;



              this.allDebitIncome=this.accountBalanceData.totalMoreThanNinety;
              this.allCreditIncome=this.accountBalanceData.totalCountMoreThanNinety;
              this.allNetMovementIncome=this.accountBalanceData.totalUnpaidAmount;


              this.allDebitExpense=this.accountBalanceData.totalMoreThanNinety;
              this.allCreditExpense=this.accountBalanceData.totalCountMoreThanNinety;
              this.allNetMovementExpense=this.accountBalanceData.totalUnpaidAmount;

              this.allDebitExpTotal=this.accountBalanceData.totalCountMoreThanNinety;
              this.allCreditExpTotal=this.accountBalanceData.totalUnpaidAmount;
              
              this.temp.agedPayablesReportDtoList.map((item) => {
               debugger;
                item.totalUnpaidAmount=item.totalAmount;
            });
          //  this.CalculateTotalPurchase();
         });
      //  }
   }
  public openPDF(): void {
    const doc = new jsPDF('p', 'pt', 'a4');
    doc.setFontSize(15);
    doc.text('Statement of Account', 400, 40);
    autoTable(doc, {
       html: '#my-table',
       styles: {
        // cellPadding: 0.5,
       // fontSize: 12,
    },
    tableLineWidth: 0.5,
    startY: 400, /* if start position is fixed from top */
    tableLineColor: [4, 6, 7], // choose RGB
      });
      const DATA = this.htmlData.nativeElement;
    doc.fromHTML(DATA.innerHTML, 30, 15);
    doc.output('dataurlnewwindow');
  }


public downloadPDF(): void {
    const doc = new jsPDF('p', 'pt', 'a4');
    doc.setFontSize(15);
    doc.text('Statement of Account', 400, 40);
    doc.text('Outstanding Invoices', 400, 70);
   autoTable(doc, {
    html: '#my-table',
    styles: {
 },
 tableLineWidth: 0.5,
 startY: 550,
 tableLineColor: [4, 6, 7], // choose RGB
   });
    autoTable(doc, {
      html: '#my-table1',
      styles: {
   },
   tableLineWidth: 0.5,
   startY: 300,
   tableLineColor: [4, 6, 7], // choose RGB
     });
    const DATA = this.htmlData.nativeElement;
    doc.save('Customer-statement.pdf');
  }


  onSubmit(form: NgForm) {
    // console.log(this.terms);
    //  console.log(this.terms.nativeElement.checked);
}
  changeStartDate(){
    debugger;
    console.log('quotatindate', this.startDate);
    const jsDate = new Date(this.startDate.year, this.startDate.month - 1, this.startDate.day);
    this.fromDate = jsDate.toISOString();
   }

   changeEnddate(){
    debugger;
    console.log('quotatindate', this.endDate);
    const jsDate = new Date(this.endDate.year, this.endDate.month - 1, this.endDate.day);
    this.toDate = jsDate.toISOString();
   }

}
