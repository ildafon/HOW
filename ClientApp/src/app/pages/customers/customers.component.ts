import {
  Component,
  OnInit,
  Inject,
  OnDestroy,
  ComponentFactoryResolver,
  ViewContainerRef,
  ViewChild,
  ElementRef,
  AfterViewInit,
  TemplateRef,
  Injector,
  ApplicationRef,
  ViewRef
} from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Customer, PagedResponse, Paging, ChannelCustomer } from '../../models';
import { PaginationObject } from '../../components/paginator/pagination-object';
import { PagingService } from '../../services/paging.service';
import { CustomerService } from '../../services/customer.service';

import { Observable, Subscription } from 'rxjs';
import { CUSTOMER_PAGING } from '../../app.config';

import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalConfirmComponent } from '../modal-confirm/modal-confirm.component';
import { ModalListComponent } from '../modal-list/modal-list.component';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit, OnDestroy, AfterViewInit {
  private subscription: Subscription;
  customers: Customer[] = [];
  selectedId: number;
  paging: Paging = {} as Paging;
  visitedId: number;

 
  


  constructor(private customerService: CustomerService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    @Inject(CUSTOMER_PAGING) private pagingService: PagingService,

   
  ) {
    
    
  }

  ngOnInit() {
    this.subscription = this.pagingService.requestObject
      .switchMap(value => this.customerService.getCustomers(value))
      .subscribe((pagedResponse: PagedResponse<Customer>) => {
        this.customers = pagedResponse.items;
        this.paging = pagedResponse.paging;

      })
    
  }

  ngAfterViewInit(): void {
    
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }






  onPage(event: PaginationObject) {
    
    this.pagingService.changeRequestObject({
      pageNumber: event.pageNumber,
      pageSize: event.pageSize
    });

  }

  onFilter(event) {
    
    this.pagingService.changeRequestObject({
      term: event.target.value
    });
  }

  onFilterFocus() {
    
    this.pagingService.changeRequestObject({
      pageNumber: 1
    });
  }

  showDetails(id) {
    this.router.navigate([{
      outlets: {
        primary: ['how', 'customers', id, 'customer-details']
      }
    }]);
  }

  createCustomer() {

    this.router.navigate([{
      outlets: {
        primary: ['how', 'customers', 'customer-add']
      }
    }]);
  }

  editCustomer(id) {
    this.router.navigate([{
      outlets: {
        primary: ['how', 'customers', id, 'customer-edit']
      }
    }]);
  }

  onDelete(id: number) {
    let modal = this.modalService.open(ModalConfirmComponent);
    modal.componentInstance.question = 'Delete Customer?';
    modal.componentInstance.dismissName = 'Cancel';
    modal.componentInstance.confirmName = 'Delete';
    modal.result.then((result) => {
      this.deleteCustomer(id);
    }, () => { });
  }

  onChannelList(list: ChannelCustomer[]) {
    let modal = this.modalService.open(ModalListComponent);
    modal.componentInstance.list = list;
  }

  deleteCustomer(id: number) {
    this.customerService.deleteCustomer(id)
      .subscribe(result => {
        this.pagingService.changeRequestObject({
          pageNumber: 1
        });
      });
  }

}

