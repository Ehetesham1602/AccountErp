import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../helpers';

import {
    LoginComponent, LogoutComponent, ChangePasswordComponent, AccountAddComponent, AccountManageComponent
} from '../components/account';

import { DashboardComponent } from '../components/dashboard/dashboard.component';

import {
    BankAccountAddComponent, BankAccountDetailComponent, BankAccountEditComponent, BankAccountManageComponent
} from '../components/bank-account';

import { CustomerAddComponent, CustomerEditComponent, CustomerDetailComponent, CustomerManageComponent } from 'src/components/customer';

import {
    CreditCardAddComponent, CreditCardDetailComponent, CreditCardEditComponent, CreditCardManageComponent
} from 'src/components/credit-card';

import {
    VendorManageComponent, VendorAddComponent, VendorDetailComponent, VendorEditComponent
} from 'src/components/vendor';

import {
    ItemAddComponent, ItemManageComponent, ItemEditComponent, ItemDetailComponent
} from 'src/components/item';

import {
    InvoiceAddComponent, InvoiceManageComponent, InvoiceEditComponent, InvoiceDetailComponent, InvoicePaymentAddComponent,
    InvoicePaymentManageComponent
} from '../components/invoice';

import {
    BillAddComponent, BillEditComponent, BillManageComponent, BillDetailComponent, BillPaymentAddComponent, BillPaymentManageComponent
} from '../components/bill';

import { CalendarManageComponent } from '../components/calendar/calendar.component';

import { SettingComponent } from '../components/setting/setting.component';

import { SalesTaxAddComponent, SalesTaxEditComponent, SalesTaxDetailComponent, SalesTaxManageComponent } from '../components/sales-tax';

const appRoutes: Routes = [
    { path: '', component: DashboardComponent, pathMatch: 'full', canActivate: [AuthGuard] },
    { path: 'account/login', component: LoginComponent },
    { path: 'account/logout', component: LogoutComponent },
    { path: 'account/change-password', component: ChangePasswordComponent },
    { path: 'account/add', component: AccountAddComponent },
    { path: 'account/manage', component: AccountManageComponent },
    { path: 'bank-account/add', component: BankAccountAddComponent },
    { path: 'bank-account/detail/:id', component: BankAccountDetailComponent },
    { path: 'bank-account/edit/:id', component: BankAccountEditComponent },
    { path: 'bank-account/manage', component: BankAccountManageComponent },
    { path: 'customer/add', component: CustomerAddComponent },
    { path: 'customer/detail/:id', component: CustomerDetailComponent },
    { path: 'customer/edit/:id', component: CustomerEditComponent },
    { path: 'customer/manage', component: CustomerManageComponent },
    { path: 'credit-card/add', component: CreditCardAddComponent },
    { path: 'credit-card/detail/:id', component: CreditCardDetailComponent },
    { path: 'credit-card/edit/:id', component: CreditCardEditComponent },
    { path: 'credit-card/manage', component: CreditCardManageComponent },
    { path: 'vendor/add', component: VendorAddComponent },
    { path: 'vendor/detail/:id', component: VendorDetailComponent },
    { path: 'vendor/edit/:id', component: VendorEditComponent },
    { path: 'vendor/manage', component: VendorManageComponent },
    { path: 'item/add', component: ItemAddComponent },
    { path: 'item/edit/:id', component: ItemEditComponent },
    { path: 'item/manage', component: ItemManageComponent },
    { path: 'item/detail/:id', component: ItemDetailComponent },
    { path: 'invoice/add', component: InvoiceAddComponent },
    { path: 'invoice/manage', component: InvoiceManageComponent },
    { path: 'invoice/edit/:id', component: InvoiceEditComponent },
    { path: 'invoice/detail/:id', component: InvoiceDetailComponent },
    { path: 'bill/add', component: BillAddComponent },
    { path: 'bill/manage', component: BillManageComponent },
    { path: 'bill/detail/:id', component: BillDetailComponent },
    { path: 'bill/edit/:id', component: BillEditComponent },
    { path: 'bill/payment/:id', component: BillPaymentAddComponent },
    { path: 'bill/payments', component: BillPaymentManageComponent },
    { path: 'setting', component: SettingComponent },
    { path: 'calendar', component: CalendarManageComponent },
    { path: 'sales-tax/add', component: SalesTaxAddComponent },
    { path: 'sales-tax/edit/:id', component: SalesTaxEditComponent },
    { path: 'sales-tax/detail/:id', component: SalesTaxDetailComponent },
    { path: 'sales-tax/manage', component: SalesTaxManageComponent },
    { path: 'invoice/payment/:id', component: InvoicePaymentAddComponent },
    { path: 'invoice/payments', component: InvoicePaymentManageComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRouting = RouterModule.forRoot(appRoutes);
