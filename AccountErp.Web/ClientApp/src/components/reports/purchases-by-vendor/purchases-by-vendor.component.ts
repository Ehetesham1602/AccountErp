import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { NgForm } from '@angular/forms';
import { AppSettings, AppUtils } from 'src/helpers';
import { PurchaseVendorsService } from 'src/services/purchase-vendors.service';
import { PurchaseVendorsDetail } from 'src/models/purchaseByVendors/purchase.vendors.model';
import { VendorDetailModel, VendorPersonalInfoModel, SelectListItemModel, BillFilterModel } from 'src/models';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { VendorService } from 'src/services';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-purchases-by-vendor',
  templateUrl: './purchases-by-vendor.component.html',
  styleUrls: ['./purchases-by-vendor.component.css']
})
export class PurchasesByVendorComponent implements OnInit {
  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;

  vendor: VendorPersonalInfoModel = new VendorPersonalInfoModel();
    vendors:any=[];
    filterModel: BillFilterModel = new BillFilterModel();

  startDate;
  endDate;
  fromDate;
  toDate;
  allPurchase;
  selectedVendor;
  config = {displayKey:"value",search:true,limitTo:10,height: 'auto',placeholder:'Select Vendor',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'value',clearOnSelection: false,inputDirection: 'ltr',}

  // "totalPurchaseAmount": 9.65,
  // "totalPaidAmount": 3.92,
  paidPurchase;
  purchaseVendortData={totalPurchaseAmount:0,totalPaidAmount:0,vendorReportsList:[{}]};
  today = new Date();
  totalPurchases;
  temp;
  model: PurchaseVendorsDetail = new PurchaseVendorsDetail();
  purchasevendor: VendorDetailModel = new VendorDetailModel();
  constructor(
    private appSettings: AppSettings,
    private purchaseVendorsService: PurchaseVendorsService,
    private vendorService: VendorService,
    private toastr: ToastrService,
        private appUtils: AppUtils,
  ) { }

  ngOnInit() {
    this.loadVendors();

  }

  showpurchasebyVendor() {
   // this.purchaseVendortData = {vendorReportsList={}};
   console.log("from",this.fromDate);
   console.log("from",this.toDate);
   if (this.selectedVendor !== undefined) {
    debugger;
    var body={ 
      "vendorId": this.selectedVendor.keyInt,
    "vendorName": "string",
    // "vendorId": this.selectedVendor.keyInt,
    "startDate":  this.fromDate,
    "endDate": this.toDate,
    "totalPaidAmount": 0,
    "totalAmount": 0,
    "status": "string"};
    

    this.purchaseVendorsService.getVendorStatement(body)
    .subscribe(
        (data) => {
          debugger
          console.log("statement",data);
         // Object.assign(this.temp, data);
             Object.assign(this.purchaseVendortData, data);
             this.allPurchase=this.purchaseVendortData.totalPurchaseAmount;
             this.paidPurchase=this.purchaseVendortData.totalPaidAmount;
             this.temp.vendorReportsList.map((item) => {
              debugger;
               item.totalPaidAmount=item.totalPurchaseAmount;
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
          this.CalculateTotalPurchase();
        });
      }
  }

  // getBalanceAccAmount(item){
  //      this.totalPurchases=0;
  //      this.tempBalance+=Number(item.totalAmount);
  //      var balAmnt=Number(this.statementData.openingBalance)+this.tempBalance;
  //      this.totalPurchases=balAmnt.toFixed(2);
  //      return balAmnt.toFixed(2);
  //  }
   getAllPurchases(){
    return this.totalPurchases;
  }
  getPaidPurchases(item){
    return item.totalAmount.toFixed(2);
  }
  CalculateTotalPurchase(){

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

   getVendorDetail() {
    debugger;
    if(this.selectedVendor!=undefined){
        this.model.vendorId=this.selectedVendor.keyInt;
    this.blockUI.start();
    this.vendor = new VendorPersonalInfoModel();
    this.vendorService.getPersonalInfo(Number(this.model.vendorId))
        .subscribe(
            (data) => {
                this.blockUI.stop();
                Object.assign(this.vendor, data);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            }
        );
    }
}

loadVendors() {
  this.vendorService.getSelectItems()
      .subscribe(
          data => {
            this.vendors=[];
              Object.assign(this.vendors, data);
          },
          error => {
              this.appUtils.ProcessErrorResponse(this.toastr, error);
          });
}

}
