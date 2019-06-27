import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Chat } from '../../models';
import { ChatService } from '../chat.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class ChatDetailResolver implements Resolve<Chat> {

  constructor(private chatService: ChatService, private router: Router) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Chat> {
    let id = route.paramMap.get("id");
    return this.chatService.getChat(+id);
  }
}
