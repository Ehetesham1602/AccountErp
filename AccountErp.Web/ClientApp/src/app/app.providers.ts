import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { AppSettings, AppUtils, JwtInterceptor, AuthGuard, NgbCustomDateParserFormatter } from '../helpers';
import {
    ListenerService, MasterDataService, AccountService, BankAccountService, CustomerService, CreditCardService,
    VendorService, ItemService, InvoiceService, BillService, PaymentService, SalesTaxService,
    BillPaymentService, InvoicePaymentService
} from '../services';

export const appProviders = [
    AppSettings,
    AppUtils,
    AuthGuard,
    ListenerService,
    MasterDataService,
    AccountService,
    BankAccountService,
    CustomerService,
    CreditCardService,
    VendorService,
    ItemService,
    InvoiceService,
    BillService,
    PaymentService,
    SalesTaxService,
    BillPaymentService,
    InvoicePaymentService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptor,
        multi: true
    },
    {
        provide: NgbDateParserFormatter,
        useClass: NgbCustomDateParserFormatter
    }
];
