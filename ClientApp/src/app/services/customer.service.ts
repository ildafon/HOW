import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { PagedResponse, Customer, RequestObject } from '../models';
import { map } from 'rxjs/operators';

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
    let reqObj = new RequestObject(1, 0, false)
    return this.getCustomers(reqObj)
      .pipe(
        map(pagedResponse => pagedResponse.items)
      );
  }

  getCustomer(id: number): Observable<Customer> {
    return this.api.sendRequest<Customer>("GET", `/api/customers/${id}`);
  }


  deleteCustomer(id: number): Observable<number> {
    return this.api.sendRequest<number>("DELETE", `/api/customers/${id}`);
  }
  
}
