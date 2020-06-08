import { AttachmentEditModel } from '../';

export class InvoiceEditModel {
    public id: number;
    public customerId: string;
    public phone: string;
    public email: string;
    public invoiceNumber: string;
    public tax: number;
    public discount: number;
    public totalAmount: number;
    public remark: string;

    public items: Array<number>;
    public attachments: Array<AttachmentEditModel>;

    constructor() {
        this.customerId = '';
        this.items = new Array<number>();
        this.attachments = new Array<AttachmentEditModel>();
    }
}
