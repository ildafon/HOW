
import { IChannelsRequestObject } from './IChannelsRequestObject';

export class ChannelsRequestObject {
  public pageNumber: number = 1;
  public pageSize: number = 5;
  public term?: string = '';
  public related: boolean = true;
}
