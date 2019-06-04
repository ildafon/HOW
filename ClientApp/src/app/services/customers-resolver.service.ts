import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Customer, RequestObject } from '../models';
import { CustomerService } from './customer.service';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class CustomersResolverService implements Resolve<Customer[]> {
  
  constructor(private cs: CustomerService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Customer[]> {
    return this.cs.getCustomersAll();
  }

}
