import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Chat, RequestObject } from '../../models';
import { ChatService } from '../chat.service';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class ChatsResolver implements Resolve<Chat[]> {
  
  constructor(private cs: ChatService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Chat[]> {
    return this.cs.getChatsAll();
  }

}
