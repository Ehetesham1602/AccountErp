import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AppSettings, AppUtils } from 'src/helpers';
import { BalanceSheetService } from 'src/services/balance-sheet.service';
import { ToastrService } from 'ngx-toastr';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { NgForm } from '@angular/forms';
import { BalanceSheetDetail } from 'src/models/balance-sheet/balance.sheet.model';

@Component({
  selector: 'app-balance-sheet',
  templateUrl: './balance-sheet.component.html',
  styleUrls: ['./balance-sheet.component.css']
})
export class BalanceSheetComponent implements OnInit {
  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  asOfDate;
  selectedstType = 'accrual';
  showSummary = true;
  showDetail = false;

  allTotalCashAndBank;
  allTotalOtherCurrentAssets;
  allTotalLongTermAssets;
  allTotalAssets;
  allTotalCurrentLiabilites;
  allTotalLongTermLiabilites;
  allTotalLiabilities;
  allTotalRetainedEarnings;
  allTotalEquity;
  allTotalOtherEquity;
  






  allTotalIncome;
  allTotalCostOfGoodSold;
  allgrossProfit;
  allGrossProfitPercentage;
  allTotalOperatingExpenses;
  allNetProfit;
  allNetProfitPercentage;
  balanceSheetData={totalIncome:0,totalUnpaidAmount:0,totalCostofGoodsSold:0,totalGrossProfit:0,
    totalGrossProfitPercentage:0,totalOperatingExpense :0,totalNetProfit:0,
    totalNetProfitPercenatge:0,agedPayablesReportDtoList:[{}]};

  model: BalanceSheetDetail = new BalanceSheetDetail();
  toggleSummary() {
    // this.showSummary = !this.showSummary;
    this.showSummary=true;
    this.showDetail=false;
  }

  toggleDetail() {
    // this.showDetail = !this.showDetail;
    this.showDetail=true;
    this.showSummary=false;
  }

  constructor(private appSettings: AppSettings,
    private balanceSheetService: BalanceSheetService,
    private toastr: ToastrService,
        private appUtils: AppUtils,) { }

  ngOnInit() {
    this.setDefaultDate();
  }


  // showBalanceSheet() {
  //   // this.purchaseVendortData = {vendorReportsList={}};
  //   // if (this.selectedVendor !== undefined) {
  //    debugger;
  //    var body={ 
  //     "vendorId": 0,
  //    "vendorName": "string",
  //    "asOfDate": "2020-07-21T06:21:14.033Z"};
     
 
  //    this.balanceSheetService.getProfitLoss(body)
  //    .subscribe(
  //        (data) => {
  //          debugger
  //          console.log("statement",data);
  //         // Object.assign(this.temp, data);
  //             Object.assign(this.balanceSheetData, data);
  //             this.allTotalIncome=this.balanceSheetData.totalIncome;
  //             this.allTotalCostOfGoodSold=this.balanceSheetData.totalCostofGoodsSold;
  //             this.allgrossProfit=this.balanceSheetData.totalGrossProfit;
  //             this.allGrossProfitPercentage=this.balanceSheetData.totalGrossProfitPercentage;
  //             this.allTotalOperatingExpenses=this.balanceSheetData.totalOperatingExpense;
  //             this.allNetProfit=this.balanceSheetData.totalNetProfit;
  //             this.allNetProfitPercentage=this.balanceSheetData.totalNetProfitPercenatge;
  //             this.temp.agedPayablesReportDtoList.map((item) => {
  //              debugger;
  //               item.totalUnpaidAmount=item.totalAmount;
  //           });
  //         //  this.CalculateTotalPurchase();
  //        });
  //     //  }
  //  }

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
  
    // this.dueDate={ day: qdt.getDate()+1, month: qdt.getMonth()+1, year: qdt.getFullYear()};
    // const jsduevDate = new Date(this.dueDate.year, this.dueDate.month - 1, this.dueDate.day);
    // this.model.dueDate=jsduevDate.toISOString();
  }
}
