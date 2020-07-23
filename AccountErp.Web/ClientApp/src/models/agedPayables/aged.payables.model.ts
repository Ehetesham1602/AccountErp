import { AddressModel } from './../address.model';
import { AttachmentDetailModel } from '../attachment/attachment.detail.model';
import { CustomerDetailModel } from '../customer/customer.detail.model';
import { InvoiceItemModel, VendorPersonalInfoModel } from '..';

export class AgedPayablesDetail {
    public id: number;
    public vendorName: string;
    public invoiceNumber: string;
    public tax: number;
    public discount: number;
    public amount: number;
    public totalAmount: number;
    public totalLessThan30: number;
    public totalThirtyFirstToSixty: number;
    public totalSixtyOneToNinety:number;
    public totalMoreThanNinety:number;
    public allPurchases: number;
    public paidPurchases: number;
    public remark: string;
    public createdOn: string;
    public startDate: string; ///
    public endDate: string; ///
    public allNotYetOverdue: number;
    public all30OrLess: number;
    public all31To60: number;
    public all61To90: number;
    public all91OrMore: number;
    public allTotalUnpaid: number;
    public asOfDate: string;
    public description: string; //
    public status: number; //
    public invoiceDate: string;
    public dueDate: string; //
    public vendorId: string;
    public customer: CustomerDetailModel;
    public vendor: VendorPersonalInfoModel;
    public items: Array<InvoiceItemModel>;
    public attachments: Array<AttachmentDetailModel>;

    constructor() {
        this.customer = new CustomerDetailModel();
        this.vendor = new VendorPersonalInfoModel();
        this.items = new Array<InvoiceItemModel>();
        this.attachments = new Array<AttachmentDetailModel>();
    }
}
