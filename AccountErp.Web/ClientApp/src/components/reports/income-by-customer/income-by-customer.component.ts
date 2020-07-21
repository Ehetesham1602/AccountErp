
import { CustomerDetailModel } from './../../../models/customer/customer.detail.model';
import { IncomeCustomerDetail } from './../../../models/incomeByCustomers/income.customer.model';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { NgForm } from '@angular/forms';
import { AppSettings, AppUtils } from 'src/helpers';
import { VendorDetailModel, VendorPersonalInfoModel, SelectListItemModel, BillFilterModel, InvoiceFilterModel } from 'src/models';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { VendorService, CustomerService } from 'src/services';
import { ToastrService } from 'ngx-toastr';
import { IncomeCustomersService } from 'src/services/income-customers.service';

@Component({
  selector: 'app-income-by-customer',
  templateUrl: './income-by-customer.component.html',
  styleUrls: ['./income-by-customer.component.css']
})
export class IncomeByCustomerComponent implements OnInit {
  @ViewChild ('terms', {static: false}) terms: ElementRef ;
  @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
  @BlockUI('container-blockui') blockUI: NgBlockUI;

  vendor: VendorPersonalInfoModel = new VendorPersonalInfoModel();
    vendors: Array<SelectListItemModel> = new Array<SelectListItemModel>();
    filterModel: InvoiceFilterModel = new InvoiceFilterModel();
  selectedCustomer;
  startDate;
  endDate;
  fromDate;
  toDate;
  allIncome;
  paidIncome;
  customers:any;
  config = {displayKey:"value",search:true,limitTo:10,height: 'auto',placeholder:'Select Customer',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'value',clearOnSelection: false,inputDirection: 'ltr',}

  // "totalPurchaseAmount": 9.65,
  // "totalPaidAmount": 3.92,
  incomeCustomertData={totalIncomeAmount:0,paidAmount:0,customerReportsDtosList:[{}]};
  today = new Date();
  totalIncome;
  temp;
  model: IncomeCustomerDetail = new IncomeCustomerDetail();
  incomecustomer: CustomerDetailModel = new CustomerDetailModel();
  constructor(
    private appSettings: AppSettings,
    private incomeCustomersService: IncomeCustomersService,
    private toastr: ToastrService,
        private appUtils: AppUtils,
    private customerService: CustomerService,
  ) { }

  ngOnInit() {
    this.loadCustomers();
  }

  // showincomebyCustomer(){

  // }
  showincomebyCustomer() {
   // this.purchaseVendortData = {vendorReportsList={}};
   console.log("from",this.fromDate);
   console.log("from",this.toDate);

    debugger;
    if (this.selectedCustomer !== undefined) {

    var body={ 
      "customerId": this.selectedCustomer.keyInt,
   
    "startDate":  this.fromDate,
    "endDate": this.toDate,
  };
    this.incomeCustomersService.getIncomeCustomer(body)
    .subscribe(
        (data) => {
          debugger
          console.log("statement",data);
         // Object.assign(this.temp, data);
             Object.assign(this.incomeCustomertData, data);
             this.allIncome=this.incomeCustomertData.totalIncomeAmount;
             this.paidIncome=this.incomeCustomertData.paidAmount;
             this.temp.customerReportsDtosList.map((item) => {
              debugger;
               item.paidAmount=item.totalIncomeAmount;
              // if(item.status==1){
              //  item.balanceAccAmount=0.00
              // }else{
              //   this.totalIncome=0;
              //   this.tempBalance+=Number(item.totalAmount);
              //   var balAmnt=Number(this.temp.openingBalance)+this.tempBalance;
              //   this.totalIncome=balAmnt.toFixed(2);
              //   item.balanceAccAmount=balAmnt.toFixed(2);
              // }
           });
          this.CalculateTotalIncome();
        });
    }
  }

  CalculateTotalIncome(){

  }


   getAllPurchases(){
    return this.totalIncome;
  }
  getPaidPurchases(item){
    return item.incomeAmount.toFixed(2);
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

   getCustomerDetail() {
    // debugger;
   // alert(this.selectedCustomer.keyInt);
     if (this.selectedCustomer !== undefined) {
         this.model.customerId = this.selectedCustomer.keyInt;
     if (this.model.customerId === null
         || this.model.customerId === '') {
        //  this.model.phone = '';
        //  this.model.email = '';
         // this.model.quotationNumber = '';
         // this.model.discount = 0;
         return;
     }
     this.customerService.getDetail(Number(this.model.customerId))
         .subscribe(
             (data) => {
                //  Object.assign(this.customer, data);
                //  this.model.phone = this.customer.phone;
                //  this.model.email = this.customer.email;
 
                //  if (!this.customer.discount) {
                //      this.customer.discount = 0;
                //  }
 
                // this.updateTotalAmount();
             });
         }
 }

 
loadCustomers() {
  this.blockUI.start();
  this.customerService.getSelectItems()
      .subscribe((data) => {
          this.blockUI.stop();
          this.customers=[];
          Object.assign(this.customers, data);
      },
          error => {
              this.blockUI.stop();
              this.appUtils.ProcessErrorResponse(this.toastr, error);
          });
}

}
