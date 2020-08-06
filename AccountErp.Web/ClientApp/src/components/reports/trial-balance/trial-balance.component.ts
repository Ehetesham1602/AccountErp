import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AppUtils, AppSettings } from 'src/helpers';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { NgForm } from '@angular/forms';
import { TrialBalanceService } from 'src/services/trial.balance.service';
import { TrialBalanceDetail } from 'src/models/trialBalance/trial.balance.model';

@Component({
  selector: 'app-trial-balance',
  templateUrl: './trial-balance.component.html',
  styleUrls: ['./trial-balance.component.css']
})
export class TrialBalanceComponent implements OnInit {

  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;

  trialBalanceData={totalAmount:0,totalUnpaidAmount:0,totalNotYetOverDue:0,totalCountNotYetOverDue:0,
    totalLessThan30:0,totalCountLessThan30 :0,totalCountThirtyFirstToSixty:0,
    totalThirtyFirstToSixty:0,totalSixtyOneToNinety:0,totalCountSixtyOneToNinety:0,
    totalMoreThanNinety:0,totalCountMoreThanNinety:0,agedPayablesReportDtoList:[{}]};
  model: TrialBalanceDetail = new TrialBalanceDetail();
  selectedstType = 'accrual';
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

  assetAccDetails;
  liabilitiesAccDetails;

  constructor(private appSettings: AppSettings,
    private trialBalanceService: TrialBalanceService,
    private toastr: ToastrService,
        private appUtils: AppUtils) { }

  ngOnInit() {

    this.setDefaultDate();

    this.assetAccDetails=[{"id":1,"accName":"Account Receivable","debit":100,"credit":50},{"id":2,"accName":"Cash on Hand","debit":10,"credit":20}]
    this.liabilitiesAccDetails=[{"id":1,"accName":"GST","debit":0.00,"credit":50}];
  }

  showTrialBalance() {
    // this.purchaseVendortData = {vendorReportsList={}};
    console.log("from",this.fromDate);
    console.log("from",this.toDate);
    // if (this.selectedVendor !== undefined) {
     debugger;
     var body={ 
      "vendorId": 0,
     "vendorName": "string",
     "asOfDate": "2020-07-21T06:21:14.033Z"};
     
 
     this.trialBalanceService.getAccountBalance(body)
     .subscribe(
         (data) => {
           debugger
           console.log("statement",data);
          // Object.assign(this.temp, data);
              Object.assign(this.trialBalanceData, data);
              this.allStartingBalance=this.trialBalanceData.totalAmount;
              this.allCreditBalance=this.trialBalanceData.totalUnpaidAmount;
              this.allDebitBalance=this.trialBalanceData.totalNotYetOverDue;
              this.allNetMovementBalance=this.trialBalanceData.totalCountNotYetOverDue;
              this.allEndingBalance=this.trialBalanceData.totalLessThan30;

              this.allStartingBalanceLiabilites=this.trialBalanceData.totalCountLessThan30;
              this.allDebitLiabilites=this.trialBalanceData.totalThirtyFirstToSixty;
              this.allCreditLiabilites=this.trialBalanceData.totalCountThirtyFirstToSixty;
              this.allNetMovementLiabilites=this.trialBalanceData.totalSixtyOneToNinety;
              this.allEndingLiabilites=this.trialBalanceData.totalCountSixtyOneToNinety;

              this.allStartingBalanceEquity=this.trialBalanceData.totalMoreThanNinety;
              this.allDebitEquity=this.trialBalanceData.totalCountMoreThanNinety;
              this.allCreditEquity=this.trialBalanceData.totalUnpaidAmount;
              this.allNetMovementEquity=this.trialBalanceData.totalAmount;
              this.allEndingEquity=this.trialBalanceData.totalCountSixtyOneToNinety;

              this.allDebitIncome=this.trialBalanceData.totalMoreThanNinety;
              this.allCreditIncome=this.trialBalanceData.totalCountMoreThanNinety;
              this.allNetMovementIncome=this.trialBalanceData.totalUnpaidAmount;


              this.allDebitExpense=this.trialBalanceData.totalMoreThanNinety;
              this.allCreditExpense=this.trialBalanceData.totalCountMoreThanNinety;
              this.allNetMovementExpense=this.trialBalanceData.totalUnpaidAmount;

              this.allDebitExpTotal=this.trialBalanceData.totalCountMoreThanNinety;
              this.allCreditExpTotal=this.trialBalanceData.totalUnpaidAmount;

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
   changeAsOfdate(){
    debugger;
    console.log('quotatindate', this.asOfDate);
    const jsDate = new Date(this.asOfDate.year, this.asOfDate.month - 1, this.asOfDate.day);
    // this.asOfDate = jsDate.toISOString();
    this.model.asOfDate=jsDate.toISOString();

   }

   setDefaultDate(){
        
    var qdt=new Date()
    this.asOfDate={ day: qdt.getDate(), month: qdt.getMonth()+1, year: qdt.getFullYear()};
    const jsbillDate = new Date(this.asOfDate.year, this.asOfDate.month - 1, this.asOfDate.day);
    this.model.asOfDate=jsbillDate.toISOString();
  }
}
