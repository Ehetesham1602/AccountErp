import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CashFlowService } from 'src/services/cash-flow.service';
import { AppSettings, AppUtils } from 'src/helpers';
import { ToastrService } from 'ngx-toastr';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { NgForm } from '@angular/forms';
import autoTable from 'jspdf-autotable';
import * as jsPDF from 'jspdf';
import { CashFlowDetail } from 'src/models/cashFlow/cash.flow.model';

@Component({
  selector: 'app-cash-flow',
  templateUrl: './cash-flow.component.html',
  styleUrls: ['./cash-flow.component.css']
})
export class CashFlowComponent implements OnInit {
  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  model: CashFlowDetail = new CashFlowDetail;
  startDate;
  endDate;
  fromDate;
  toDate;
  showSummary = true;
  showDetail = false;

  allSales;
  allPurchases;
  allSalesTaxes;
  allNetCashOperatingActivites;
  allNetCashInvestingActivites;
  allNetCashFinancingActivites;
  allStartingBalance;
  allGrossCashInflow;
  allGrossCashOutflow;
  allNetCashChange;
  allEndingBalance;
  



  cashFlowData={totalIncome:0,totalUnpaidAmount:0,totalCostofGoodsSold:0,totalGrossProfit:0,
    totalGrossProfitPercentage:0,totalOperatingExpense :0,totalNetProfit:0,
    totalNetProfitPercenatge:0,agedPayablesReportDtoList:[{}]};

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

 

  // model: ProfitLossDetail = new ;
  constructor( private cashFlowService: CashFlowService,
    private appSettings: AppSettings,
    private toastr: ToastrService,
        private appUtils: AppUtils,) { }

  ngOnInit() {
  }


  // showCashFlow() {
  //   // this.purchaseVendortData = {vendorReportsList={}};
  //   console.log("from",this.fromDate);
  //   console.log("from",this.toDate);
  //   // if (this.selectedVendor !== undefined) {
  //    debugger;
  //    var body={ 
  //     "vendorId": 0,
  //    "vendorName": "string",
  //    "asOfDate": "2020-07-21T06:21:14.033Z"};
     
 
  //    this.profitLossService.getCashFlow(body)
  //    .subscribe(
  //        (data) => {
  //          debugger
  //          console.log("statement",data);
  //         // Object.assign(this.temp, data);
  //             Object.assign(this.cashFlowData, data);
  //             this.allTotalIncome=this.cashFlowData.totalIncome;
  //             this.allTotalCostOfGoodSold=this.cashFlowData.totalCostofGoodsSold;
  //             this.allgrossProfit=this.cashFlowData.totalGrossProfit;
  //             this.allGrossProfitPercentage=this.cashFlowData.totalGrossProfitPercentage;
  //             this.allTotalOperatingExpenses=this.cashFlowData.totalOperatingExpense;
  //             this.allNetProfit=this.cashFlowData.totalNetProfit;
  //             this.allNetProfitPercentage=this.cashFlowData.totalNetProfitPercenatge;
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
