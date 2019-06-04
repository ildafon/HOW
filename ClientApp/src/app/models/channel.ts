import { ChannelCustomer } from './channelCustomer';



export class Channel {
  constructor(
    public channelId?: number,
    public name?: string,
    public isActive?: boolean,
    public channelCustomers: ChannelCustomer[] = []
    ) { }
}
