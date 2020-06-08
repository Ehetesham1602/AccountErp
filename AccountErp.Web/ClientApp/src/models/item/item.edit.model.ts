export class ItemEditModel {
    public id: number;
    public itemTypeId: string;
    public name: string;
    public rate: number;
    public discription: string;
    public isTaxable: string;
    public salesTaxId: string;

    constructor() {
        this.itemTypeId = '';
        this.salesTaxId = '';
        this.isTaxable = '0';
    }
}
