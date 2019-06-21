import { Component, OnInit, Inject } from '@angular/core';
import { Customer, Channel, ChannelCustomer, Avatar } from '../../models';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { CUSTOMER_PAGING } from '../../app.config';
import { PagingService } from '../../services/paging.service';
import { NgForm } from '@angular/forms';
import { AvatarService } from '../../services/avatar.service';
import { isNullOrUndefined } from 'util';

export const placeholder = '/assets/placeholder.png';
export interface dbPath {
  dbPath: string
}

export interface RouteResolvedData {
  title: string,
  customer?: Customer,
  channels?: Channel[]
}

@Component({
  selector: 'app-customer-editor',
  templateUrl: './customer-editor.component.html',
  styleUrls: ['./customer-editor.component.css']
})
export class CustomerEditorComponent implements OnInit {

  title: string;
  customer: Customer = new Customer();
  channelsAvailable: Channel[] = [];
  channelsSelected: boolean[] = [];
  isNew: boolean = true;
  formSubmitted: boolean = false;
  

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService,
    private avatarService: AvatarService,
    @Inject(CUSTOMER_PAGING) private pagingService: PagingService
  ) { }

  ngOnInit() {
    this.route.data.subscribe((data: RouteResolvedData) => {
      this.title = data.title;

      if (data.hasOwnProperty('channels')) {
        this.channelsAvailable = data.channels;
        this.channelsSelected = new Array(this.channelsAvailable.length).fill(false);

      }

      if (data.hasOwnProperty('customer')) {
        this.isNew = false;
        this.customer = data.customer;
        

        this.channelsSelected = this.channelsAvailable.map((value, index, array) => {
          return this.customer.channelCustomers.map(cc => cc.channelId).includes(array[index].channelId);
        });
        this.pagingService.changeRequestObject({ visitedId: this.customer.customerId });
      }

      if (!this.customer.avatar) this.customer.avatar = new Avatar(0, placeholder);
    });

   

  }

  onSubmit(form: NgForm) {
    this.formSubmitted = true;
    if (form.valid) {
      this.customer.channelCustomers = [];
      
      
      this.channelsSelected.forEach((value, index) => {
        if (value) {
          this.customer.channelCustomers.push(
            new ChannelCustomer(this.channelsAvailable[index].channelId)
          );
        }
      });

      this.isNew ? this.onCreate() : this.onUpdate();
    }
  }

  uploadFinished(event: dbPath) {
    let avatar = new Avatar();
    avatar.url = event.dbPath;

    this.avatarService.createAvatar(avatar).subscribe((result: Avatar) => {
      this.customer.avatarId = result.avatarId;
      this.customer.avatar.url = result.url;
    });
    
    
  }

  getCustomerAvatar() {
    return this.customer.avatar.url;
  }

  private onCreate() {
    this.customerService.createCustomer(this.customer)
      .subscribe((customer: Customer) => {
        this.pagingService.changeRequestObject({ visitedId: customer });
        this.backToCustomers();
      });
  }

  private onUpdate() {
    this.customerService.updateCustomer(this.customer)
      .subscribe((customer: Customer) => {
        this.backToCustomers();
      })
  }

  backToCustomers() {
    this.router.navigate(['/how/customers']);
  }

}
