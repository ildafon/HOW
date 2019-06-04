import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { PagedResponse, Channel, RequestObject, Customer } from '../models';


@Injectable()
export class ChannelService {
  private channels: Channel[];
  private customers: Customer[];

  constructor(private api: ApiService) { }

  getChannels(channelRequestObj: RequestObject): Observable<PagedResponse<Channel>> {
    return this.api.sendRequest<PagedResponse<Channel>>("GET", '/api/channels'
      + '?Related=' + channelRequestObj.related
      + '&PageNumber=' + channelRequestObj.pageNumber
      + '&PageSize=' + channelRequestObj.pageSize
      + '&Term=' + channelRequestObj.term);
  }

  getChannel(id: number): Observable<Channel> {
    return this.api.sendRequest<Channel>("GET", `/api/channels/${id}`);
  }

  createChannel(channel: Channel): Observable<Channel> {
    let data: Channel = {
      name: channel.name,
      channelCustomers: channel.channelCustomers
    };

    return this.api.sendRequest<Channel>("POST", '/api/channels', data);
  }

  editChannel(channel: Channel): Observable<Channel> {
    let data: Channel = {
      channelId: channel.channelId,
      name: channel.name,
      channelCustomers: channel.channelCustomers
    };

    return this.api.sendRequest<Channel>("PUT", `/api/channels/${channel.channelId}`, data);
  }


  deleteChannel(id: number): Observable<number> {
    return this.api.sendRequest<number>("DELETE", `/api/channels/${id}`);
  }
}
