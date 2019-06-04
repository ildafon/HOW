import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { PagedResponse, Customer, RequestObject, Channel } from '../models';

@Injectable()
export class CustomerService {

  constructor(private api: ApiService) { }

  getCustomers(customerRequestObject: RequestObject): Observable<PagedResponse<Customer>> {
    return this.api.sendRequest<PagedResponse<Customer>>("GET", '/api/customers'
      + '?Related=' + customerRequestObject.related
      + '&PageNumber=' + customerRequestObject.pageNumber
      + '&PageSize=' + customerRequestObject.pageSize
      + '&Term=' + customerRequestObject.term);
  }

  getCustomersAll(): Observable<Customer[]> {
    return this.api.sendRequest<Customer[]>("GET", '/api/customers/all');
  }

  getCustomer(id: number): Observable<Customer> {
    return this.api.sendRequest<Customer>("GET", `/api/customers/${id}`);
  }
}
