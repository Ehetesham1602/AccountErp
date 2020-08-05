import { SalesTaxService } from './../../../services/sales.tax.service';
import { Component, OnInit, ViewChild, ElementRef, EventEmitter, Output, Input } from '@angular/core';
import { AppSettings, AppUtils } from 'src/helpers';
import { ToastrService } from 'ngx-toastr';
import { SalesTaxReportService } from 'src/services/sales-tax-report.service';
import autoTable from 'jspdf-autotable';
import * as jsPDF from 'jspdf';
import { NgForm } from '@angular/forms';
import { SelectListItemModel, ItemListItemModel } from 'src/models';
import { SalesTAxReportDetail } from 'src/models/sales-tax-report/sales.tax.report.model';
import { NgBlockUI, BlockUI } from 'ng-block-ui';

@Component({
  selector: 'app-sales-tax-report',
  templateUrl: './sales-tax-report.component.html',
  styleUrls: ['./sales-tax-report.component.css']
})
export class SalesTaxReportComponent implements OnInit {
  [x: string]: any;
  @BlockUI('container-blockui-main') blockUI: NgBlockUI;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  itemType: Array<SelectListItemModel> = new Array<SelectListItemModel>();
  @Output() updateTotalAmount = new EventEmitter();
  @Input() selectedTax: any=[];
  @Input() selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();
  salesTaxes: Array<SelectListItemModel> = new Array<SelectListItemModel>();

  @Input() taxList;
  config = {displayKey:"name",search:true,height: 'auto',placeholder:'Select Item',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'name',clearOnSelection: false,inputDirection: 'ltr',}
  config2 = {displayKey:"code",search:true,height: 'auto',placeholder:'Select Item',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'code',clearOnSelection: false,inputDirection: 'ltr',}

  model: SalesTAxReportDetail = new SalesTAxReportDetail();

  reportType = 'accural';
  salesPurchaseData={totalTaxAmountOnSales:0,totalTaxAmountOnPurchase:0,totalNetTaxOwing:0,salesTaxReportDtosList:[{}]}; 
  paymentBalanceData;
  allPurchase;
  allTaxAmountOnSales;
  alltaxAmountonPurchase;
  allNetTaxOwing;
  allStartingBalance;
  allEndingBalance;
  allLessPaymenttoGovt;
  temp;
  selectedReportType;
  // selectedTax;
   //salesTaxes:any[];
   sales:any;
  startDate;
  endDate;
  fromDate;
  toDate;
  salesTaxItems;
  constructor(private appSettings: AppSettings,
    private salesTaxReportService: SalesTaxReportService,
    private toastr: ToastrService,
        private appUtils: AppUtils,
        private salesTaxService: SalesTaxService,) { }

  ngOnInit() {
    this.loadSalesTax();
    this.loadTaxes();
    this.setDefaultDate();
    this.showSalesTaxReport();
  }



  public openPDF(): void {
    const doc = new jsPDF('p', 'pt', 'a4');
    doc.setFontSize(15);
    doc.text('Sales Tax Report', 400, 40);
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
    doc.text('Sales Tax Report', 400, 40);
    doc.text('', 400, 70);
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
    doc.save('Sales-Tax.pdf');
  }


  onSubmit(form: NgForm) {
    // console.log(this.terms);
    //  console.log(this.terms.nativeElement.checked);
}


    showSalesTaxReport(){
      debugger;
        // this.purchaseVendortData = {vendorReportsList={}};
   console.log("from",this.fromDate);
   console.log("from",this.toDate);
   var body
   if (this.selectedTax !== undefined) {
    // if (this.selectedReportType !== undefined) {
    debugger;
    body={ 
      "salesId": this.selectedTax.id,
        "startDate":  this.fromDate,
        "endDate":  this.toDate,

        "reportType": 0
    };
  // }
    }else{
          body={ 
            "salesId": 0,
              "startDate":  this.fromDate,
              "endDate":  this.toDate,
      
              "reportType": 0
          }; 
        }

    this.salesTaxReportService.getSalesTaxStatement(body)
    .subscribe(
        (data) => {
          debugger
          console.log("statement",data);
         // Object.assign(this.temp, data);
             Object.assign(this.salesPurchaseData, data);
             this.allTaxAmountOnSales=this.salesPurchaseData.totalTaxAmountOnSales;
             this.alltaxAmountonPurchase=this.salesPurchaseData.totalTaxAmountOnPurchase;
             this.allNetTaxOwing=this.salesPurchaseData.totalNetTaxOwing;

             this.temp.salesTaxReportDtosList.map((item) => {
              debugger;
               item.totalPaidAmount=item.totalTaxAmountOnSales;
              // if(item.status==1){
              //  item.balanceAccAmount=0.00
              // }else{
              //   this.totalPurchases=0;
              //   this.tempBalance+=Number(item.totalAmount);
              //   var balAmnt=Number(this.temp.openingBalance)+this.tempBalance;
              //   this.totalPurchases=balAmnt.toFixed(2);
              //   item.balanceAccAmount=balAmnt.toFixed(2);
              // }
           });
          //this.CalculateTotalPurchase();
        });
      // }
    // }
    }
changeTax(index,event){
        debugger;
        console.log("tax ngmodel after",event)
       
       // alert(event.target.Value)
        this.selectedItems[index].salesTaxId=this.selectedTax[index].id;
        this.selectedItems[index].taxPercentage=Number(this.selectedTax[index].taxPercentage);
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

   setDefaultDate(){
    debugger;
          
    var startDate = new Date(new Date().getFullYear(), 0, 1);
    this.startDate={ day: startDate.getDate(), month: startDate.getMonth()+1, year: startDate.getFullYear()};
    const jsbillDate = new Date(this.startDate.year, this.startDate.month - 1, this.startDate.day);
    this.fromDate=jsbillDate.toISOString();
  
    var endDate = new Date();
    this.endDate={ day: endDate.getDate(), month: endDate.getMonth()+1, year: endDate.getFullYear()};
    const jsduevDate = new Date(this.endDate.year, this.endDate.month - 1, this.endDate.day);
    this.toDate=jsduevDate.toISOString();
  }
//    getSalesTax() {
//     debugger;
//     if(this.selectedTax!=undefined){
//         this.model.salesId=this.selectedTax.keyInt;
//     this.blockUI.start();
//     this.salesTax = new VendorPersonalInfoModel();
//     this.salesTaxService.getPersonalInfo(Number(this.model.salesId))
//         .subscribe(
//             (data) => {
//                 this.blockUI.stop();
//                 Object.assign(this.salesTax, data);
//             },
//             error => {
//                 this.blockUI.stop();
//                 this.appUtils.ProcessErrorResponse(this.toastr, error);
//             }
//         );
//     }
// }

getSalesTax() {
  debugger;
   if (this.selectedTax !== undefined) {
       this.model.salesId = this.selectedTax.keyInt;
   if (this.model.salesId === null
       || this.model.salesId === '') {
       return;
   }
   this.salesTaxService.getDetail(Number(this.model.salesId))
       .subscribe(
           (data) => {
           });
       }
}




loadTaxes() {
  // this.blockUI.start();
  this.salesTaxService.getSelectListItems()
      .subscribe((data) => {
          // this.blockUI.stop();
          this.sales=[];
          Object.assign(this.sales, data);
      },
          error => {
              // this.blockUI.stop();
              this.appUtils.ProcessErrorResponse(this.toastr, error);
          });
}

loadSalesTax() {
  debugger;
  // this.blockUI.start();
  this.salesTaxService.getSelectListItems()
      .subscribe((data) => {
          // this.blockUI.stop();
          Object.assign(this.salesTaxes, data);
          console.log("taxlist",this.salesTaxes)
      },
          error => {
              // this.blockUI.stop();
              this.appUtils.ProcessErrorResponse(this.toastr, error);
          });
}



}
