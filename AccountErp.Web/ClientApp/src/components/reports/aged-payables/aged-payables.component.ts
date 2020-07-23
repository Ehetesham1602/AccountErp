import { VendorService } from './../../../services/vendor.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { VendorPersonalInfoModel, BillFilterModel, VendorDetailModel } from 'src/models';
import { PurchaseVendorsDetail } from 'src/models/purchaseByVendors/purchase.vendors.model';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { NgForm } from '@angular/forms';
import { AppSettings, AppUtils } from 'src/helpers';
import { ToastrService } from 'ngx-toastr';
import { AgedPayablesDetail } from 'src/models/agedPayables/aged.payables.model';
import { AgedPayablesService } from 'src/services/aged.payables.service';

@Component({
  selector: 'app-aged-payables',
  templateUrl: './aged-payables.component.html',
  styleUrls: ['./aged-payables.component.css']
})
export class AgedPayablesComponent implements OnInit {

//   @ViewChild ('terms', {static: false}) terms: ElementRef ;
//   @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
//   @BlockUI('container-blockui') blockUI: NgBlockUI;

//   vendor: VendorPersonalInfoModel = new VendorPersonalInfoModel();
//     vendors:any=[];
//     filterModel: BillFilterModel = new BillFilterModel();

//   startDate;
//   endDate;
//   fromDate;
//   toDate;
//   asOfDate;
//   allPurchase;
//   selectedVendor;
//   config = {displayKey:"value",search:true,limitTo:10,height: 'auto',placeholder:'Select Vendor',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'value',clearOnSelection: false,inputDirection: 'ltr',}

//   // "totalPurchaseAmount": 9.65,
//   // "totalPaidAmount": 3.92,
//   paidPurchase;
//   agedPayablesData={totalAmount:0,totalUnpaidAmount:0,totalNotYetOverDue:0,totalCountNotYetOverDue:0,
//     totalLessThan30:0,totalCountLessThan30 :0,totalCountThirtyFirstToSixty:0,
//     totalThirtyFirstToSixty:0,totalSixtyOneToNinety:0,totalCountSixtyOneToNinety:0,
//     totalMoreThanNinety:0,totalCountMoreThanNinety:0,agedPayablesReportDtoList:[{}]};

  
//   allNotYetOverdue;
//   all30OrLess;
//   all31To60;
//   all61To90;
//   all91OrMore;
//   allTotalUnpaid;
//   allTotalAmount;
//   today = new Date();
//   totalPurchases;
//   temp;
//   model: AgedPayablesDetail = new AgedPayablesDetail();
//   purchasevendor: VendorDetailModel = new VendorDetailModel();

//   constructor(  private appSettings: AppSettings,
//     private agedPayableService: AgedPayablesService,
//     private vendorService: VendorService,
//     private toastr: ToastrService,
//         private appUtils: AppUtils,) { }

   ngOnInit() {
//     this.setDefaultDate();
//     this.loadVendors();
  }

//   showAgedPayablesReport() {
//     // this.purchaseVendortData = {vendorReportsList={}};
//     console.log("from",this.fromDate);
//     console.log("from",this.toDate);
//     // if (this.selectedVendor !== undefined) {
//      debugger;
//      var body={ 
//       "vendorId": 0,
//       //  "vendorId": this.selectedVendor.keyInt,
//      "vendorName": "string",
//     //  "startDate":  this.fromDate,
//     //  "endDate": this.toDate,
//     //  "totalPaidAmount": 0,
//     //  "totalAmount": 0,
//     //  "status": "string"
//     //  "vendorId": 0,
//      "asOfDate": "2020-07-21T06:21:14.033Z"};
     
 
//      this.agedPayableService.getAgedPayable(body)
//      .subscribe(
//          (data) => {
//            debugger
//            console.log("statement",data);
//           // Object.assign(this.temp, data);
//               Object.assign(this.agedPayablesData, data);
//               // this.allPurchase=this.agedPayablesData.totalAmount;
//               this.paidPurchase=this.agedPayablesData.totalUnpaidAmount;

//               // this.allNotYetOverdue=this.agedPayablesData.totalNotYetOverDue;
//               this.allNotYetOverdue=this.agedPayablesData.totalCountNotYetOverDue;
//               // this.all30OrLess=this.agedPayablesData.totalLessThan30;
//               this.all30OrLess=this.agedPayablesData.totalCountLessThan30;
//               // this.all31To60=this.agedPayablesData.totalThirtyFirstToSixty;
//               this.all31To60=this.agedPayablesData.totalCountThirtyFirstToSixty;
//               // this.all61To90=this.agedPayablesData.totalSixtyOneToNinety;
//               this.all61To90=this.agedPayablesData.totalCountSixtyOneToNinety;
//               // this.all91OrMore=this.agedPayablesData.totalMoreThanNinety;
//               this.all91OrMore=this.agedPayablesData.totalCountMoreThanNinety;
//               this.allTotalUnpaid=this.agedPayablesData.totalUnpaidAmount;
//               this.allTotalAmount=this.agedPayablesData.totalAmount;
//               this.temp.agedPayablesReportDtoList.map((item) => {
//                debugger;
//                 item.totalUnpaidAmount=item.totalAmount;
                
//             });
//           //  this.CalculateTotalPurchase();
//          });
//       //  }
//    }
//   public openPDF(): void {
//     const doc = new jsPDF('p', 'pt', 'a4');
//     doc.setFontSize(15);
//     doc.text('Statement of Account', 400, 40);
//     autoTable(doc, {
//        html: '#my-table',
//        styles: {
//         // cellPadding: 0.5,
//        // fontSize: 12,
//     },
//     tableLineWidth: 0.5,
//     startY: 400, /* if start position is fixed from top */
//     tableLineColor: [4, 6, 7], // choose RGB
//       });
//       const DATA = this.htmlData.nativeElement;
//     doc.fromHTML(DATA.innerHTML, 30, 15);
//     doc.output('dataurlnewwindow');
//   }


// public downloadPDF(): void {
//     const doc = new jsPDF('p', 'pt', 'a4');
//     doc.setFontSize(15);
//     doc.text('Statement of Account', 400, 40);
//     doc.text('Outstanding Invoices', 400, 70);
//    autoTable(doc, {
//     html: '#my-table',
//     styles: {
//  },
//  tableLineWidth: 0.5,
//  startY: 550,
//  tableLineColor: [4, 6, 7], // choose RGB
//    });
//     autoTable(doc, {
//       html: '#my-table1',
//       styles: {
//    },
//    tableLineWidth: 0.5,
//    startY: 300,
//    tableLineColor: [4, 6, 7], // choose RGB
//      });
//     const DATA = this.htmlData.nativeElement;
//     doc.save('Customer-statement.pdf');
//   }


//   onSubmit(form: NgForm) {
//     // console.log(this.terms);
//     //  console.log(this.terms.nativeElement.checked);
// }
//   changeStartDate(){
//     debugger;
//     console.log('quotatindate', this.startDate);
//     const jsDate = new Date(this.startDate.year, this.startDate.month - 1, this.startDate.day);
//     this.fromDate = jsDate.toISOString();
//    }

//    changeEnddate(){
//     debugger;
//     console.log('quotatindate', this.endDate);
//     const jsDate = new Date(this.endDate.year, this.endDate.month - 1, this.endDate.day);
//     this.toDate = jsDate.toISOString();
//    }

//    changeAsOfdate(){
//     debugger;
//     console.log('quotatindate', this.asOfDate);
//     const jsDate = new Date(this.asOfDate.year, this.asOfDate.month - 1, this.asOfDate.day);
//     // this.asOfDate = jsDate.toISOString();
//     this.model.asOfDate=jsDate.toISOString();

//    }

//    getVendorDetail() {
//     debugger;
//     if(this.selectedVendor!=undefined){
//         this.model.vendorId=this.selectedVendor.keyInt;
//     this.blockUI.start();
//     this.vendor = new VendorPersonalInfoModel();
//     this.vendorService.getPersonalInfo(Number(this.model.vendorId))
//         .subscribe(
//             (data) => {
//                 this.blockUI.stop();
//                 Object.assign(this.vendor, data);
//             },
//             error => {
//                 this.blockUI.stop();
//                 this.appUtils.ProcessErrorResponse(this.toastr, error);
//             }
//         );
//     }
// }

// loadVendors() {
//   this.vendorService.getSelectItems()
//       .subscribe(
//           data => {
//             this.vendors=[];
//               Object.assign(this.vendors, data);
//           },
//           error => {
//               this.appUtils.ProcessErrorResponse(this.toastr, error);
//           });
// }

// setDefaultDate(){
        
//   var qdt=new Date()
//   this.asOfDate={ day: qdt.getDate(), month: qdt.getMonth()+1, year: qdt.getFullYear()};
//   const jsbillDate = new Date(this.asOfDate.year, this.asOfDate.month - 1, this.asOfDate.day);
//   this.model.asOfDate=jsbillDate.toISOString();

//   // this.dueDate={ day: qdt.getDate()+1, month: qdt.getMonth()+1, year: qdt.getFullYear()};
//   // const jsduevDate = new Date(this.dueDate.year, this.dueDate.month - 1, this.dueDate.day);
//   // this.model.dueDate=jsduevDate.toISOString();
// }
}
