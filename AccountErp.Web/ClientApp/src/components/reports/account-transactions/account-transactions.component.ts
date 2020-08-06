import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import autoTable from 'jspdf-autotable';
import * as jsPDF from 'jspdf';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { AppSettings, AppUtils } from 'src/helpers';
import { AccountTransactionsService } from 'src/services/account-transactions.service';
import { ToastrService } from 'ngx-toastr';
import { AccountTransactionDetail } from 'src/models/accountTransaction/accountTransaction.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-account-transactions',
  templateUrl: './account-transactions.component.html',
  styleUrls: ['./account-transactions.component.css']
})
export class AccountTransactionsComponent implements OnInit {

  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  model: AccountTransactionDetail = new AccountTransactionDetail();
  accountList=[{accmaster:"",accounts:[]}];
  allAccounts;
  endDate;
  fromDate;
  toDate;
  startDate;
  temp;
  dates;
  selectedDate;
  selectedstType = 'accrual';
  selectedstContact;
  config = {displayKey:"value",search:true,limitTo:10,height: 'auto',placeholder:'Select Customer',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'value',clearOnSelection: false,inputDirection: 'ltr',}
  
  accountTransactionData = {totalAmount:0,totalUnpaidAmount:0,totalNotYetOverDue:0,totalCountNotYetOverDue:0,
    totalLessThan30:0,totalCountLessThan30 :0,totalCountThirtyFirstToSixty:0,
    totalThirtyFirstToSixty:0,totalSixtyOneToNinety:0,totalCountSixtyOneToNinety:0,
    totalMoreThanNinety:0,totalCountMoreThanNinety:0,agedPayablesReportDtoList:[{}]};

    
  constructor(private appSettings: AppSettings,
    private route: ActivatedRoute,
    private accountTransactionService: AccountTransactionsService,
    private toastr: ToastrService,
        private appUtils: AppUtils,) {
debugger;
          this.route.params.subscribe((params) => {
            if (params['id']) {
              alert(params['id'])
              this.model.accountId= params['id'];
              
            }
        });
         }

  ngOnInit( ) {
    this.loadAccounts();
  }
  onSubmit(form: NgForm) {
    // console.log(this.terms);
    //  console.log(this.terms.nativeElement.checked);
}

loadAccounts(){
  this.blockUI.start();
  this.accountTransactionService.getAllaccounts()
      .subscribe((data) => {
          debugger;
          this.blockUI.stop();
         
         
          this.allAccounts=[];
          var master=[];

          Object.assign(this.allAccounts, data);
          console.log("all accounts",this.allAccounts)
         
      },
          error => {
              this.blockUI.stop();
              this.appUtils.ProcessErrorResponse(this.toastr, error);
          });
  
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
  selectAccount(event){
    alert(this.model.accountId);
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

  showAccountTransaction(){
    // this.purchaseVendortData = {vendorReportsList={}};
    console.log("from",this.fromDate);
    console.log("from",this.toDate);
 
     debugger;
    //  if (this.selectedCustomer !== undefined) {
 
     var body={ 
      //  "customerId": this.selectedCustomer.keyInt,
      "customerId":0,
     "asOfDate": "2020-07-21T06:21:14.033Z"
   };
     this.accountTransactionService.getAccountTransaction(body)
     .subscribe(
      (data) => {
        debugger
        console.log("statement",data);
           Object.assign(this.accountTransactionData, data);
           // this.allPurchase=this.accountTransactionData.totalAmount;
          //  this.paidPurchase=this.accountTransactionData.totalUnpaidAmount;

          //  // this.allNotYetOverdue=this.accountTransactionData.totalNotYetOverDue;
          //  this.allNotYetOverdue=this.accountTransactionData.totalCountNotYetOverDue;
          //  // this.all30OrLess=this.accountTransactionData.totalLessThan30;
          //  this.all30OrLess=this.accountTransactionData.totalCountLessThan30;
          //  // this.all31To60=this.accountTransactionData.totalThirtyFirstToSixty;
          //  this.all31To60=this.accountTransactionData.totalCountThirtyFirstToSixty;
          //  // this.all61To90=this.accountTransactionData.totalSixtyOneToNinety;
          //  this.all61To90=this.accountTransactionData.totalCountSixtyOneToNinety;
          //  // this.all91OrMore=this.accountTransactionData.totalMoreThanNinety;
          //  this.all91OrMore=this.accountTransactionData.totalCountMoreThanNinety;
          //  this.allTotalUnpaid=this.accountTransactionData.totalUnpaidAmount;
          //  this.allTotalAmount=this.accountTransactionData.totalAmount;

           this.temp.agedPayablesReportDtoList.map((item) => {
            debugger;
             item.totalUnpaidAmount=item.totalAmount;
             
         });
       //  this.CalculateTotalPurchase();
      });

  }
}
