import { Customer } from './customer.model';
import { channelCustomer } from './channelCustomers';

export interface Channel {
  channelId: number;
  name: string;
  isActive?: boolean;
  channelCustomers?: channelCustomer[]
}
