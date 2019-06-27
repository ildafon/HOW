import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Chat, PagedResponse, Paging, Message, Visitor, Customer } from '../../models';
import { PaginationObject } from '../../components/paginator/pagination-object';
import { PagingService } from '../../services/paging.service';
import { ChatService } from '../../services/chat.service';
import { Observable, Subscription } from 'rxjs';

import { CHAT_PAGING } from '../../app.config';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalConfirmComponent } from '../modal-confirm/modal-confirm.component';


export interface IRouterData {
  title: string,
  chats?: Chat[]
}

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.css']
})
export class ChatsComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  chats: Chat[] = [];
  selectedId: number;
  paging: Paging = {} as Paging;
  visitedId: number;

  constructor(
    private chatService: ChatService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    @Inject(CHAT_PAGING) private pagingService: PagingService
    
  ) { }

  ngOnInit() {
    this.subscription = this.pagingService.requestObject
      .switchMap(value => this.chatService.getChats(value))
      .subscribe((pagedResponse: PagedResponse<Chat>) => {
        this.chats = pagedResponse.items.filter(chat => chat.isActive);
        this.paging = pagedResponse.paging;
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  onArchive(id: number) {
    let modal = this.modalService.open(ModalConfirmComponent);
    modal.componentInstance.question = 'Archive this chat?';
    modal.componentInstance.dismissName = 'Cancel';
    modal.componentInstance.confirmName = 'Archivate';
    modal.result.then((result) => {
      this.archivate(id);
    }, () => { });
  }

  archivate(id: number) { }

  showDetails(id: number) {
    this.router.navigate(['how', 'chats', id, 'chat-details']);
  }
}
