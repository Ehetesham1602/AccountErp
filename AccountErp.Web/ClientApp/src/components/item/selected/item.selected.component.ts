import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { ItemListItemModel, SalesTaxAddModel } from '../../../models';
import { QuotationAddComponent } from 'src/components/Quotation';

import { ItemCalculationService } from 'src/services/item-calculation.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { QuotationService } from 'src/services/quotation.service.service';
import { ToastrService } from 'ngx-toastr';
import { AppUtils } from 'src/helpers';

@Component({
    selector: 'app-item-selected',
    templateUrl: './item.selected.component.html'
})

export class ItemSelectedComponent implements OnInit{
    @BlockUI('container-blockui') blockUI: NgBlockUI;
    modalReference: any;
    @Input() selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    @Input() readOnly: boolean;
    selectedItemListItemModel : ItemListItemModel=new ItemListItemModel();
    ItemListItemModel : ItemListItemModel=new ItemListItemModel();
    itemsandservices : any=[];
    @Input() itemId : Array<ItemListItemModel> = new Array<ItemListItemModel>();
    @Input() testVariable:string;
    @Input() taxList;
    config = {displayKey:"name",search:true,height: 'auto',placeholder:'Select Item',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'name',clearOnSelection: false,inputDirection: 'ltr',}
    config2 = {displayKey:"code",search:true,height: 'auto',placeholder:'Select Item',customComparator: ()=>{},moreText: 'more',noResultsFound: 'No results found!',searchPlaceholder:'Search',searchOnKey: 'code',clearOnSelection: false,inputDirection: 'ltr',}
   // taxList : Array<SalesTaxAddModel> =new Array<SalesTaxAddModel>();
   // selectedTax: Array<SalesTaxAddModel> =new Array<SalesTaxAddModel>();
    @Input() selectedTax: any=[];
    @Input() disabled : boolean = true;
    
 
    @Output() deleteItem = new EventEmitter();
    @Output() updateTotalAmount = new EventEmitter();

    constructor(private itemService: ItemCalculationService,
                private QuotationService:QuotationService,
                private toastr: ToastrService,
                private appUtils: AppUtils,) {}

    ngOnInit(): void {
        this.initiateGrid();
        debugger;
        this.loadItems();
        this.loadTaxes();
        
        //this.taxList=[{"code":"txt1","taxPercentage":"0.4","description":"",},{"code":"txt2","taxPercentage":"10","description":""}]

//         this.itemsandservices=[
// {"description": "DESC1",
// "id": 1,
// "itemTypeName": 1,
// "name": "Sample Item1",
// "price": 100,
// "qty": 1,
// "rate": 100,
// "taxCode": "txt1",
// "taxPercentage": 0.4
//     },
// {"description": "DESCdest22",
// "id": 2,
// "itemTypeName": 1,
// "name": "Sample Item2",
// "price": 200,
// "qty": 1,
// "rate": 200,
// "taxCode": "txt2",
// "taxPercentage": 10
// },
// {
//     "description": "DESCdest33",
//     "id": 3,
//     "itemTypeName": 1,
//     "name": "Sample Item3",
//     "price": 100,
//     "qty": 1,
//     "rate": 100,
//     "taxCode": "txt1",
//     "taxPercentage": 0.4
// }]

console.log("itesm",this.itemsandservices)

     

    //    this.ItemListItemModel.id=1;
    //    this.ItemListItemModel.itemTypeName=1;
    //    this.ItemListItemModel.name="Sample Item";
    //    this.ItemListItemModel.rate=10;
    //    this.ItemListItemModel.taxCode="txt1";
    //    this.ItemListItemModel.taxPercentage=10;
    //    this.ItemListItemModel.description="DESC";
    //    this.ItemListItemModel.price=0;
    //    this.ItemListItemModel.qty=1;
    //    this.itemsandservices.push(this.ItemListItemModel);

    //    this.ItemListItemModel.id=2;
    //    this.ItemListItemModel.itemTypeName=2;
    //    this.ItemListItemModel.name="Sample Item2";
    //    this.ItemListItemModel.rate=300;
    //    this.ItemListItemModel.taxCode="txt2";
    //    this.ItemListItemModel.taxPercentage=0.5;
    //    this.ItemListItemModel.description="Sampleitem2";
    //    this.ItemListItemModel.price=300;
    //    this.ItemListItemModel.qty=1;
    //    this.itemsandservices.push(this.ItemListItemModel);

    //    this.ItemListItemModel.id=3;
    //    this.ItemListItemModel.itemTypeName=1;
    //    this.ItemListItemModel.name="Sample Item3";
    //    this.ItemListItemModel.rate=100;
    //    this.ItemListItemModel.taxCode="txt1";
    //    this.ItemListItemModel.taxPercentage=0.40;
    //    this.ItemListItemModel.description="DESCdest";
    //    this.ItemListItemModel.price=100;
    //    this.ItemListItemModel.qty=1;
    //    this.itemsandservices.push(this.ItemListItemModel);



       //alert(this.selectedItems.length)
    }



    getItemDetail(rowindx:any){
        debugger;
//if(!this.selectedItems.find(e=> e.id==this.itemId[rowindx].id)){
    this.itemId[rowindx].qty=1;
    this.itemId[rowindx].price=this.itemId[rowindx].rate;
    this.selectedItems[rowindx]=this.itemId[rowindx];
    this.selectedTax[rowindx]=this.itemId[rowindx].taxCode;
// }else{
//     this.itemId.splice(0,rowindx);
// }


 





    }

    initiateGrid(){
        debugger;
        // alert("ng oninit called")
       // this.itemId=null;
      this.selectedItemListItemModel.id=0;
      this.selectedItemListItemModel.itemTypeName="";
      this.selectedItemListItemModel.name="Select Item";
      this.selectedItemListItemModel.rate=0;
      this.selectedItemListItemModel.taxCode="";
      this.selectedItemListItemModel.taxPercentage=0;
      this.selectedItemListItemModel.description="Desc";
      this.selectedItemListItemModel.price=0;
      this.selectedItemListItemModel.qty=1;
      this.selectedItems.push(this.selectedItemListItemModel);
      console.log("kfjdkfj",this.itemId)
      
    }

    loadItems() {
        debugger;
        this.blockUI.start();
        this.QuotationService.getAllItemsActive()
            .subscribe((data) => {
                debugger;
                this.blockUI.stop();
                
               
                this.itemsandservices=[];
                Object.assign(this.itemsandservices, data);
                console.log("customers",this.itemsandservices)
                // if(this.customers.length>0){
                //     this.customrlist=[];
                //     this.customers.forEach(element => {
                //         this.customrlist.push({"id":element.id,"value":element.value})
                //     });
                // }
               
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    loadTaxes() {
        debugger;
        this.blockUI.start();
        this.QuotationService.getAllTaxes()
            .subscribe((data) => {
                debugger;
                this.blockUI.stop();
                
               
                this.taxList=[];
                Object.assign(this.taxList, data);
                console.log("taxs",this.taxList)
                // if(this.customers.length>0){
                //     this.customrlist=[];
                //     this.customers.forEach(element => {
                //         this.customrlist.push({"id":element.id,"value":element.value})
                //     });
                // }
               
            },
                error => {
                    this.blockUI.stop();
                    this.appUtils.ProcessErrorResponse(this.toastr, error);
                });
    }

    changeRate(event,rowindx){
        debugger;
       // alert(event.target.value)
        console.log(this.selectedItems[rowindx])
        this.selectedItems[rowindx].rate=Number(event.target.value);
        this.selectedItems[rowindx].price=Number(this.selectedItems[rowindx].rate)*Number(this.selectedItems[rowindx].qty);
    }

    changeQty(event,rowindx){
        debugger;
      //  alert(event.target.value)
        console.log(this.selectedItems[rowindx])
        this.selectedItems[rowindx].qty=Number(event.target.value);
        this.selectedItems[rowindx].price=Number(this.selectedItems[rowindx].rate)*Number(this.selectedItems[rowindx].qty);

    }

    deleteSelected(index){
        this.itemId.splice(index, 1);
    }

    changeTax(index,event){
        debugger;
        console.log("tax ngmodel after",event)
       
       // alert(event.target.Value)
        this.selectedItems[index].salesTaxId=this.selectedTax[index].id;
        this.selectedItems[index].taxPercentage=Number(this.selectedTax[index].taxPercentage);
    }
    
}

