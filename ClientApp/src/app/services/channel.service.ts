import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { ApiService } from './api.service';
import { PagedResponse, Channel, RequestObject, IRequestObject, Customer } from '../models';
import { LocalStorageService } from './local-storage.service';



@Injectable()
export class ChannelService {
  private requestObjestInitial: RequestObject;

  private requestObject$ = new BehaviorSubject <RequestObject>(this.getRequestObjectInitial());
  get currentRequestObject() {
    return this.requestObject$.getValue();
  }
  get requestObject() {
    return this.requestObject$.asObservable();
  }

  

  constructor(private api: ApiService, private localStorageService: LocalStorageService) {
   
     
  }


  changeRequestObject(reqObj: Object) {
    //console.log("changeRequestObject call!");
    this.requestObject$.next((<any>Object).assign(this.requestObject$.value, reqObj));
    this.localStorageService.setItem<RequestObject>(`CHANNEL_REQUEST_OBJECT`, this.currentRequestObject);
  }



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


  deleteChannel(id: number): Observable<number>{
    return this.api.sendRequest<number>("DELETE", `/api/channels/${id}`);
  }

  refresh() {
    this.requestObject$.next((<any>Object).assign(this.requestObject$.value, {}));
  }

  private getRequestObjectInitial() {
    return this.localStorageService
      .getItem<RequestObject>(`CHANNEL_REQUEST_OBJECT`) || new RequestObject;
  }
}
