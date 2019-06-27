import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiService } from './api.service';
import { PagedResponse, RequestObject, Chat } from '../models';


@Injectable()
export class ChatService {

  constructor(private api: ApiService) { }


  getChats(reqObj: RequestObject): Observable<PagedResponse<Chat>> {
    return this.api.sendRequest<PagedResponse<Chat>>("GET", '/api/chats'
      + '?Related=' + reqObj.related
      + '&PageNumber=' + reqObj.pageNumber
      + '&PageSize=' + reqObj.pageSize
      + '&Term=' + reqObj.term);
  }

  getChatsAll(): Observable<Chat[]> {
    let reqObj = new RequestObject(1, 0, false);
    return this.getChats(reqObj)
      .pipe(
        map(pagedResponse => pagedResponse.items)
      );
  }

  getChat(id: number): Observable<Chat> {
    return this.api.sendRequest<Chat>("GET", `/api/chats/${id}`);
  }
}
