import { AppComponent } from './app.component';

import { HeaderComponent, HeaderMobileComponent, SideNavComponent, FooterComponent } from '../components/shared';

import {
    LoginComponent, LogoutComponent, ChangePasswordComponent, AccountManageComponent, AccountAddComponent
} from '../components/account';

import { DashboardComponent } from '../components/dashboard/dashboard.component';

import {
    BankAccountAddComponent, BankAccountDetailComponent, BankAccountEditComponent,
    BankAccountManageComponent
} from '../components/bank-account';

import {
    CustomerFromWizarNavigatorComponent, CustomerFromWizardAsideComponent, CustomerPersonalInformationComponent,
    CustomerAddressDetailComponent, CustomerPaymentDetailComponent, CustomerDiscountDetailComponent,
    CustomerDetailComponent, CustomerAddComponent, CustomerEditComponent, CustomerManageComponent, CustomerShippingaddressComponent, AddCustomerPopupComponent
} from '../components/customer';

import {
    CreditCardAddComponent, CreditCardDetailComponent, CreditCardEditComponent, CreditCardManageComponent
} from '../components/credit-card';

import {
    VendorFromWizardAsideComponent, VendorFromWizarNavigatorComponent, VendorPersonalInformationComponent,
    VendorBillingAddressDetailComponent, VendorShippingAddressDetailComponent, VendorContactDetailComponent, VendorPaymentDetailComponent,
    VendorDiscountDetailComponent, VendorManageComponent, VendorAddComponent, VendorDetailComponent, VendorEditComponent
} from '../components/vendor';


import {
    SalesTaxListComponent, SalesTaxManageComponent, SalesTaxAddComponent, SalesTaxEditComponent, SalesTaxDetailComponent
} from '../components/sales-tax';

import {
    ItemAddComponent, ItemManageComponent, ItemEditComponent, ItemDetailComponent,
    ItemSelectorComponent, ItemSelectedComponent
} from '../components/item';

import {
    InvoiceAddComponent, InvoiceManageComponent, InvoiceEditComponent, InvoiceDetailComponent, InvoiceListComponent,
    InvoiceRecentComponent, InvoicePaymentAddComponent, InvoicePaymentManageComponent, InvoicePaymentListComponent
} from '../components/invoice';

import {
    BillAddComponent, BillEditComponent, BillManageComponent, BillDetailComponent, BillPaymentAddComponent, BillPaymentManageComponent,
    BillListComponent, BillRecentPendingComponent, BillPaymentListComponent
} from '../components/bill';

import { CalendarManageComponent } from '../components/calendar/calendar.component';

import { DefaultIfEmpty } from '../helpers/app.pipes';

import {
    AlphabatesOnlyDirective, AlphabatesWithSpaceOnlyDirective, AlphabatesALevelOneDirective, AlphabatesALevelTwoDirective,
    NumbersOnlyDirective, DecimalNumbersOnlyDirective, AlphaNumericsOnlyDirective, AlphaNumericsLevelOneDirective,
    AlphaNumericsLevelTwoDirective, AlphaNumericsLevelThreeDirective, AlphaNumericsLevelFourDirective, AnythingButWhiteSpaceDirective,
    EmailAddressOnlyDirective, PhoneNumberOnlyDirective, WebUrlOnlyDirective, ZipCodeOnlyDirective
} from '../helpers/app.directives';

import { SettingComponent } from '../components/setting/setting.component';
import { QuotationAddComponent,QuotationDetailComponent,QuotationManageComponent,QuotationEditComponent } from '../components/Quotation';
import { CustomerStatementComponent } from 'src/components/customer-statement/customer-statement.component';

export const appDeclarations = [
    DefaultIfEmpty,
    AlphabatesOnlyDirective,
    AlphabatesWithSpaceOnlyDirective,
    AlphabatesALevelOneDirective,
    AlphabatesALevelTwoDirective,
    DecimalNumbersOnlyDirective,
    NumbersOnlyDirective,
    AlphaNumericsOnlyDirective,
    AlphaNumericsLevelOneDirective,
    AlphaNumericsLevelTwoDirective,
    AlphaNumericsLevelThreeDirective,
    AlphaNumericsLevelFourDirective,
    AnythingButWhiteSpaceDirective,
    EmailAddressOnlyDirective,
    PhoneNumberOnlyDirective,
    WebUrlOnlyDirective,
    ZipCodeOnlyDirective,
    AppComponent,
    HeaderMobileComponent,
    HeaderComponent,
    SideNavComponent,
    FooterComponent,
    LoginComponent,
    LogoutComponent,
    ChangePasswordComponent,
    DashboardComponent,
    AccountAddComponent,
    AccountManageComponent,
    BankAccountAddComponent,
    BankAccountDetailComponent,
    BankAccountEditComponent,
    BankAccountManageComponent,
    CustomerFromWizarNavigatorComponent,
    CustomerFromWizardAsideComponent,
    CustomerPersonalInformationComponent,
    CustomerAddressDetailComponent,
    CustomerShippingaddressComponent,
    CustomerPaymentDetailComponent,
    CustomerDiscountDetailComponent,
    CustomerAddComponent,
    AddCustomerPopupComponent,
   
    CustomerDetailComponent,
    CustomerEditComponent,
    CustomerManageComponent,
    CreditCardAddComponent,
    CreditCardDetailComponent,
    CreditCardEditComponent,
    CreditCardManageComponent,
    VendorFromWizardAsideComponent,
    VendorFromWizarNavigatorComponent,
    VendorPersonalInformationComponent,
    VendorBillingAddressDetailComponent,
    VendorShippingAddressDetailComponent,
    VendorContactDetailComponent,
    VendorPaymentDetailComponent,
    VendorDiscountDetailComponent,
    VendorAddComponent,
    VendorDetailComponent,
    VendorEditComponent,
    VendorManageComponent,
    SalesTaxListComponent,
    ItemAddComponent,
    ItemEditComponent,
    ItemManageComponent,
    ItemDetailComponent,
    ItemSelectorComponent,
    ItemSelectedComponent,
    InvoiceAddComponent,
    InvoiceManageComponent,
    InvoiceEditComponent,
    InvoiceDetailComponent,
    InvoiceRecentComponent,
    InvoicePaymentAddComponent,
    InvoicePaymentManageComponent,
    InvoicePaymentListComponent,
    BillAddComponent,
    BillManageComponent,
    BillDetailComponent,
    BillEditComponent,
    BillListComponent,
    BillPaymentAddComponent,
    BillPaymentListComponent,
    BillRecentPendingComponent,
    BillPaymentManageComponent,
    SettingComponent,
    CalendarManageComponent,
    InvoiceListComponent,
    SalesTaxManageComponent,
    SalesTaxAddComponent,
    SalesTaxEditComponent,
    SalesTaxDetailComponent,
    QuotationAddComponent,
    QuotationDetailComponent,
    QuotationManageComponent,
    QuotationEditComponent,
    CustomerStatementComponent
];
