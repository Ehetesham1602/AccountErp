import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { AppSettings, AppUtils, JwtInterceptor, AuthGuard, NgbCustomDateParserFormatter } from '../helpers';
import {
    ListenerService, MasterDataService, AccountService, BankAccountService, CustomerService, CreditCardService,
    VendorService, ItemService, InvoiceService, BillService, PaymentService, SalesTaxService,
    BillPaymentService, InvoicePaymentService
} from '../services';
import { ItemCalculationService } from 'src/services/item-calculation.service';
import { CustomerStatementService } from 'src/services/customer-statement.service';
import { recurringOptions } from 'src/helpers/recurringOptions';
import { chartOfAccountsList } from 'src/components/chart-of-account/chartOfAccountsList';

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
    ItemCalculationService,
    CustomerStatementService,
    chartOfAccountsList,
    recurringOptions,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptor,
        multi: true
    }
   
];
