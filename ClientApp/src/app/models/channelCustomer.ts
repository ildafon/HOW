import { Customer } from "./customer";
import { Channel } from './channel';


export class ChannelCustomer {
  constructor(
    public channelId?: number,
    public customerId?: number,
    public customer?: Customer,
    public channel?: Channel
  ) { }
}
