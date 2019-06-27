import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Chat, Message } from '../../models';
import { Subscription } from 'rxjs';
import { CHAT_PAGING } from '../../app.config';
import { PagingService } from '../../services/paging.service';
import { Location } from '@angular/common';

export interface RouteData {
  title: string,
  chat?: Chat
}

@Component({
  selector: 'app-chat-detail',
  templateUrl: './chat-detail.component.html',
  styleUrls: ['./chat-detail.component.css']
})
export class ChatDetailComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  title: string;
  chat: Chat;
  messages: Message[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
    @Inject(CHAT_PAGING) private pagingService: PagingService,
  ) { }

  ngOnInit() {
    this.subscription = this.route.data.subscribe((data: RouteData) => {
      this.chat = data.chat;
      this.title = data.title;
      this.pagingService.changeRequestObject({ visitedId: this.chat.chatId })
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  backToChats() {
    this.router.navigate(['/how/chats']);
  }

  back() {
    this.location.back();
  }
}
