import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from 'src/helpers';
import { CustomerStatementDetail } from 'src/models/customerStatement/customer.statement.detail.model';

@Injectable()
export class CustomerStatementService {

  constructor(private http: HttpClient,
    private appSettings: AppSettings) { }

  add(model: CustomerStatementDetail) {
    return this.http.post(this.appSettings.ApiBaseUrl + 'Customer/Add', model);
  }

  getCustomerStatement(){
    debugger;
    var body=[{
      "id": 0,
  "customerId": 0,
  "startDate": "2020-06-19T08:32:51.329Z",
  "endDate": "2020-06-19T08:32:51.329Z",
  "status": 0,
 }]
    return this.http.post(this.appSettings.ApiBaseUrl + 'Customer/get-customer-statement',body[0]);
  }

  toggleStatus(id: number) {
    return this.http.post(this.appSettings.ApiBaseUrl + 'Customer/toggle-status/' + id, null);
  }

  delete(id: number) {
    return this.http.post(this.appSettings.ApiBaseUrl + 'Customer/delete/' + id, null);
  }

  getForEdit(id: number) {
    return this.http.get(this.appSettings.ApiBaseUrl + 'Customer/get-for-edit/' + id);
  }

  edit(model: CustomerStatementDetail) {
    return this.http.post(this.appSettings.ApiBaseUrl + 'Customer/edit', model);
  }

  getDetail(id: number) {
    return this.http.get(this.appSettings.ApiBaseUrl + 'Customer/get-detail/' + id);
  }

  getSelectItems() {
    return this.http.get(this.appSettings.ApiBaseUrl + 'Customer/get-select-items');
  }

  getPaymentInfo(id: number) {
    return this.http.get(this.appSettings.ApiBaseUrl + 'customer/get-payment-info/' + id);
  }

  getReferenceNumber(customerId: any) {
    return this.http.get(this.appSettings.ApiBaseUrl + 'Customer/get-reference-number/' + customerId);
  }
}
