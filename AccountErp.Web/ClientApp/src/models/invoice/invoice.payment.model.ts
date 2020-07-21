export class InvoicePaymentModel {
    public id: number;
    public invoiceId: number;
    public paymentMode:string;
    public paymentDate : string;
    public bankAccountId: string;
    public depositFrom: string;
    public chequeNumber:string;
    public description:string;
    public customerId:string;

    constructor() {
        this.paymentMode = '';
        this.bankAccountId = '';
        this.depositFrom = '';
    }
}
