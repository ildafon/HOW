import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiService } from './api.service';
import { PagedResponse, RequestObject, Avatar } from '../models';

@Injectable()
export class AvatarService {

  constructor(private api: ApiService) { }

  getAvatars(): Observable<Avatar[]> {
    return this.api.sendRequest <Avatar[]>("GET", '/api/avatars');
  }

  getAvatar(id: number): Observable<Avatar> {
    return this.api.sendRequest<Avatar>("GET", `/api/avatars/${id}`);
  }

  createAvatar(avatar: Avatar): Observable<Avatar> {
    let data: Avatar = {
      url: avatar.url
    }

    return this.api.sendRequest<Avatar>("POST", 'api/avatars', data);
  }
}
