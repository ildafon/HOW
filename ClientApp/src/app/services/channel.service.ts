import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { PagedResponse, Channel, ChannelsRequestObject } from '../models';




@Injectable()
export class ChannelService {
  private channels: Channel[];

  constructor(private api: ApiService) { }


 


  getChannels(channelRequestObj: ChannelsRequestObject): Observable<PagedResponse<Channel>> {
    return this.api.sendRequest<PagedResponse<Channel>>("GET", '/api/channels'
      + '?Related=' + channelRequestObj.related
      + '&PageNumber=' + channelRequestObj.pageNumber
      + '&PageSize=' + channelRequestObj.pageSize
      + '&Term=' + channelRequestObj.term
    );
  }

  getChannel(id: number): Observable<Channel> {
    return this.api.sendRequest<Channel>("GET", `/api/channels/${id}`);
  }
}
