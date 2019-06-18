import { Avatar } from './avatar';
import { Chat } from './chat';
import { Channel } from './channel';
import { ChannelCustomer } from './channelCustomer';


export class Customer  {
  constructor(
    public customerId?: number,
    public name?: string,
    public email?: string,
    public avatar?: Avatar,
    public channelCustomers: ChannelCustomer[]=[],
    public chats: Chat[] = []
  ) { }
}


