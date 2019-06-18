import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Customer } from '../../models';
import { CustomerService } from '../customer.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class CustomerDetailResolver implements Resolve<Customer> {

  constructor(private customerService: CustomerService, private router: Router) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Customer> {
    let id = route.paramMap.get("id");
    return this.customerService.getCustomer(+id);
  }
}
