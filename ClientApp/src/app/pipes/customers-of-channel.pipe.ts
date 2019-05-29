import { Pipe, PipeTransform } from '@angular/core';
import { Channel } from '../models/channel.model';
import { channelCustomer } from '../models/channelCustomers';


@Pipe({
  name: 'customersOfChannel'
})
export class CustomersOfChannelPipe implements PipeTransform {

  transform(ch: Channel, args?: any): string {
    let result: string[] = [];
    if (ch.channelCustomers && ch.channelCustomers.length > 0) {
      for (let cust of ch.channelCustomers) {
        result.push(cust.customer.name);
        console.log();
      }
    }
    return result.length > 0 ? result.join(', '): '';
     
  }

}
