import { Component, OnInit } from '@angular/core';
import { Channel, Customer, ChannelCustomer } from '../../models';
import { ActivatedRoute, Router } from '@angular/router';
import { ChannelService } from '../../services/channel.service';
import { NgForm } from '@angular/forms';
import { forEach } from '@angular/router/src/utils/collection';

export interface IRouterData {
  title: string,
  channel?: Channel,
  customers?: Customer[]
}


@Component({
  selector: 'app-channel-editor',
  templateUrl: './channel-editor.component.html',
  styleUrls: ['./channel-editor.component.css']
})
export class ChannelEditorComponent implements OnInit {
  title: string;
  channel: Channel = new Channel();
  isNew: boolean = true;
  formSubmitted: boolean = false;
  customersAvailable: Customer[];
  customersSelector: boolean[];

  constructor(private route: ActivatedRoute, private cs: ChannelService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe((data: IRouterData) => {
      this.title = data.title;

      if (data.hasOwnProperty('customers')) {
        this.customersAvailable = data.customers;
        this.customersSelector = new Array(data.customers.length).fill(false);
      }

      if (data.hasOwnProperty('channel')) {
        this.channel = data.channel;
        this.customersSelector = this.customersAvailable.map((value, index, array) => {
          return data.channel.channelCustomers.map(cc => cc.customerId).includes(array[index].customerId);
        })
        this.isNew = false;
        this.cs.changeRequestObject({ visitedId: this.channel.channelId });
      }
      
    });
    
  }
  
  onSubmit(form: NgForm) {
    this.formSubmitted = true;
    
    if (form.valid) {
      this.channel.channelCustomers = [];
      this.customersSelector.forEach((value, index) => {
        if (value) {
          this.channel.channelCustomers.push(
            new ChannelCustomer(this.channel.channelId, this.customersAvailable[index].customerId));
        }
      });

      this.isNew ? this.onCreate() : this.onEdit();
    }
  }

  private onCreate() {
    this.cs.createChannel(this.channel)
      .subscribe((ch: Channel) => {
        
        this.cs.changeRequestObject({ visitedId: ch});
        this.router.navigate(['/how/channels']);
      });
  }

  private onEdit() {
    this.cs.editChannel(this.channel)
      .subscribe((channel: Channel) => {
        this.router.navigate(['/how/channels']);
      });
  }

  backToChannels() {
    this.router.navigate(['/how/channels']);
  }
  

}
