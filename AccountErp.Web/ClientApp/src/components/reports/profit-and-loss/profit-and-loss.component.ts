import { ProfitLossService } from './../../../services/profit-loss.service';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ProfitLossDetail } from 'src/models/profitAndLoss/profit.loss.model';
import { NgForm } from '@angular/forms';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import autoTable from 'jspdf-autotable';
import * as jsPDF from 'jspdf';
import { AppUtils, AppSettings } from 'src/helpers';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profit-and-loss',
  templateUrl: './profit-and-loss.component.html',
  styleUrls: ['./profit-and-loss.component.css']
})
export class ProfitAndLossComponent implements OnInit {
  
  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;
  selectedstType = 'accrual';
  startDate;
  endDate;
  fromDate;
  toDate;
  showSummary = true;
  showDetail = false;
  temp;
  selectedDateRange;

  allTotalIncome;
  allTotalCostOfGoodSold;
  allgrossProfit;
  allGrossProfitPercentage;
  allTotalOperatingExpenses;
  allNetProfit;
  allNetProfitPercentage;

  profitAndLossData={totalIncome:0,totalUnpaidAmount:0,totalCostofGoodsSold:0,totalGrossProfit:0,
    totalGrossProfitPercentage:0,totalOperatingExpense :0,totalNetProfit:0,
    totalNetProfitPercenatge:0,agedPayablesReportDtoList:[{}]};


    dates = [
      {group: 'Africa', items: [
          {id: '1', value: 'Africa/Abidjan', text: 'Africa - Abidjan'},
          {id: '2', value: 'Africa/Accra', text: 'Africa - Accra'},
          {id: '3', value: 'Africa/Addis_Ababa', text: 'Africa - Addis Ababa'},
          {id: '4', value: 'Africa/Algiers', text: 'Africa - Algiers'},
          {id: '5', value: 'Africa/Asmara', text: 'Africa - Asmara'},
        ]},
      {group: 'America', items: [
          {id: '6', value: 'America/Adak', text: 'America - Adak'},
          {id: '7', value: 'America/Anchorage', text: 'America - Anchorage'},
          {id: '8', value: 'America/Anguilla', text: 'America - Anguilla'},
          {id: '9', value: 'America/Antigua', text: 'America - Antigua'},
          {id: '10', value: 'America/Araguaina', text: 'America - Araguaina'},
        ]}
      ]
    config = {displayKey:"value",search:true,limitTo:10,height: 'auto',placeholder:'Select Date Range',
                customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',
                searchOnKey: 'value',clearOnSelection: false,inputDirection: 'ltr',}

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

  // tslint:disable-next-line:member-ordering
  model: ProfitLossDetail = new ProfitLossDetail;

  constructor(    private profitLossService: ProfitLossService,
    private appSettings: AppSettings,
    private toastr: ToastrService,
        private appUtils: AppUtils,
    ) { }

  ngOnInit() {


  }

  
  showProfitLoss() {
    // this.purchaseVendortData = {vendorReportsList={}};
    // console.log("from",this.fromDate);
    // console.log("from",this.toDate);
    // // if (this.selectedVendor !== undefined) {
    //  debugger;
    //  var body={ 
    //   "vendorId": 0,
    //  "vendorName": "string",
    //  "asOfDate": "2020-07-21T06:21:14.033Z"};
     
 
    //  this.profitLossService.getProfitLoss(body)
    //  .subscribe(
    //      (data) => {
    //        debugger
    //        console.log("statement",data);
    //       // Object.assign(this.temp, data);
    //           Object.assign(this.profitAndLossData, data);
    //           this.allTotalIncome=this.profitAndLossData.totalIncome;
    //           this.allTotalCostOfGoodSold=this.profitAndLossData.totalCostofGoodsSold;
    //           this.allgrossProfit=this.profitAndLossData.totalGrossProfit;
    //           this.allGrossProfitPercentage=this.profitAndLossData.totalGrossProfitPercentage;
    //           this.allTotalOperatingExpenses=this.profitAndLossData.totalOperatingExpense;
    //           this.allNetProfit=this.profitAndLossData.totalNetProfit;
    //           this.allNetProfitPercentage=this.profitAndLossData.totalNetProfitPercenatge;
    //           this.temp.agedPayablesReportDtoList.map((item) => {
    //            debugger;
    //             item.totalUnpaidAmount=item.totalAmount;
    //         });
    //       //  this.CalculateTotalPurchase();
    //      });
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

   getDateRangeDetail(){

   }
}
