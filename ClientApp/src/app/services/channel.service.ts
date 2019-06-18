import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiService } from './api.service';
import { PagedResponse, Channel, RequestObject } from '../models';




@Injectable()
export class ChannelService {

  constructor(private api: ApiService) {}


  getChannels(channelRequestObj: RequestObject): Observable<PagedResponse<Channel>> {
    return this.api.sendRequest<PagedResponse<Channel>>("GET", '/api/channels'
      + '?Related=' + channelRequestObj.related
      + '&PageNumber=' + channelRequestObj.pageNumber
      + '&PageSize=' + channelRequestObj.pageSize
      + '&Term=' + channelRequestObj.term);
  }

  getChannelsAll(): Observable<Channel[]> {
    let channelReqObj = new RequestObject(1, 0, false);
    return this.getChannels(channelReqObj)
      .pipe(
        map((response: PagedResponse<Channel>) => response.items)
      )
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


  deleteChannel(id: number): Observable<number>{
    return this.api.sendRequest<number>("DELETE", `/api/channels/${id}`);
  }

}
