import { Component, OnInit, OnDestroy, HostBinding, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Customer } from '../../models';
import { CUSTOMER_PAGING } from '../../app.config';
import { PagingService } from '../../services/paging.service';
import { Location } from '@angular/common';

export interface RouteData  {
  title: string,
  customer?: Customer,
  customers?: Customer[]
}

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  customer: Customer;
  title: string;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    @Inject(CUSTOMER_PAGING) private pagingService: PagingService,
    private location: Location
  ) { }

  ngOnInit() {
    this.subscription = this.route.data.subscribe((data: RouteData) => {
      this.customer = data.customer;
      this.title = data.title;
      this.pagingService.changeRequestObject({ visitedId: this.customer.customerId })
    })
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  backToCustomers() {
    this.router.navigate(['/how/customers']);
  }

  back() {
    this.location.back();
  }

  editCustomer() {
    this.router.navigate(['/how/customers', this.customer.customerId, 'customer-edit']);
  }

}
