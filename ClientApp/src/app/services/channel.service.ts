import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { ApiService } from './api.service';
import { PagedResponse, Channel, RequestObject, Customer } from '../models';


@Injectable()
export class ChannelService {
  
  private requestObject$: BehaviorSubject<RequestObject> = new BehaviorSubject(new RequestObject);
  get currentRequestObject() {
    return this.requestObject$.getValue();
  }
  requestObject = this.requestObject$.asObservable();

  
  changeRequestObject(reqObj: Object) {
    this.requestObject$.next((<any>Object).assign(this.requestObject$.value, reqObj));
  }

  //get term(): string {
  //  return this.requestObject$.value.term;
  //}

  //set term(t: string) {
  //  this.requestObject$.next(Object.assign(this.requestObject$.value, { term: t }));
  //}

  //get page(): number {
  //  return this.requestObject$.value.pageNumber;
  //}


  constructor(private api: ApiService) { }

  getChannelsPaged(channelRequestObj: RequestObject): Observable<PagedResponse<Channel>> {
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
