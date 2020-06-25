import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import * as jsPDF from 'jspdf';
import { AppUtils } from '../../../helpers';
import { InvoiceDetailModel, ItemListItemModel } from '../../../models';
import { InvoiceService, ItemService, SalesTaxService } from '../../../services';

@Component({
    selector: 'app-invoice-detail',
    templateUrl: './invoice.detail.component.html'
})

export class InvoiceDetailComponent implements OnInit {
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    multiSelectDropdownConfigs: IDropdownSettings;
    model: InvoiceDetailModel = new InvoiceDetailModel();
    items: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    salesTaxItems;
  
    itemId: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    selectedTax;
    
    @ViewChild('htmlData', {static: false}) htmlData: ElementRef;
    constructor(private router: Router,
        private route: ActivatedRoute,
        private toastr: ToastrService,
        private appUtils: AppUtils,
        private invoiceService: InvoiceService,
        private taxService:SalesTaxService,
        private itemService: ItemService) {
        this.route.params.subscribe((params) => {
            this.model.id = params['id'];
        });
    }

    ngOnInit() {
        this.loadItems();
        this.loadTaxes();
        this.loadInvoice();
    }
    public openPDF(): void {
        const DATA = this.htmlData.nativeElement;
        
        const doc = new jsPDF('p', 'pt', 'a4');
        
        doc.fromHTML(DATA.innerHTML, 15, 15);
        doc.output('dataurlnewwindow');

        
      }
    public downloadPDF(): void {
        const DATA = this.htmlData.nativeElement;
        const doc = new jsPDF('p', 'pt', 'a4');
        const handleElement = {
          '#editor': function(element, renderer) {
            return true;
          }
        };
        doc.fromHTML(DATA.innerHTML, 15, 15, {
          'width': 200,
          'elementHandlers': handleElement
        });
        doc.save('Invoice-Detail.pdf');
      }
    loadInvoice() {
        this.blockUI.start();
        this.invoiceService.getDetail(this.model.id).subscribe(
            (data: any) => {
                this.blockUI.stop();
                Object.assign(this.model, data);
                this.model.createdOn = this.appUtils.getFormattedDate(this.model.createdOn, null);
                this.model.invoiceDate = this.appUtils.getFormattedDate(this.model.invoiceDate, null);
                this.model.dueDate = this.appUtils.getFormattedDate(this.model.dueDate, null);

                this.updateSelectedItems();
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

    loadItems() {
        this.itemService.getAllActiveOnly()
            .subscribe((data: any) => {
                if (!data || data.length === 0) {
                    return;
                }

                this.items = data;

                this.updateSelectedItems();
            },
                error => {
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    updateSelectedItems() {
     
        if (this.items.length === 0 || this.model.items.length === 0) {
            return;
        }
    
        const tempArray = new Array<ItemListItemModel>();
         const tempTax=[]
       // this.model.totalAmount = 0;
        this.model.items.map((invoiceItem) => {
            const item = this.items.find(x => x.id === invoiceItem.id);
            console.log("itemss",invoiceItem)
            if (item) {
                 item.rate = invoiceItem.rate;
                 item.qty= invoiceItem.quantity;
                 item.rate=invoiceItem.rate;
                 item.price=invoiceItem.price;
                 item.description=invoiceItem.description;
                 
                 tempArray.push(item);
    
                //this.model.totalAmount += invoiceItem.rate;
                //Get item taxes
                debugger;
                if(invoiceItem.taxId!=0){
                    const taxitem=this.salesTaxItems.find(x=> x.id===invoiceItem.taxId);
                    tempTax.push(taxitem);
 
                }else{
                    tempTax.push(null)
                }
            }
    
            
        });
    
        this.selectedItems = tempArray;
       // this.itemId=[];
        this.itemId=tempArray;
        this.selectedTax=tempTax;
        console.log("bindselecteditem",this.itemId);
    }

    loadTaxes(){
        this.taxService.getSelectListItems()
            .subscribe((data: any) => {
                if (!data || data.length === 0) {
                    return;
                }

                this.salesTaxItems = data;

                 this.updateSelectedItems();
            },
                error => {
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    delete(): void {
        if (!confirm('Are you sure you want to delete the selected invoice?')) {
            return;
        }
        this.blockUI.start();
        this.invoiceService.delete(this.model.id).subscribe(
            () => {
                this.blockUI.stop();
                setTimeout(() => {
                    this.router.navigate(['/invoice/manage']);
                }, 100);
                setTimeout(() => {
                    this.toastr.success('Invoice has been deleted successfully.');
                }, 500);
            },
            error => {
                this.blockUI.stop();
                this.appUtils.ProcessErrorResponse(this.toastr, error);
            });
    }

    print() {
        window.open(location.origin + '/print/invoice/' + this.model.id);
    }

}
