import { Component, OnInit, Inject, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import { Subscription, BehaviorSubject } from 'rxjs';
import { ChannelService } from '../../services/channel.service';

import { PaginationObject } from '../../components/paginator/pagination-object';
import { PaginatorComponent } from '../../components/paginator/paginator.component';
import { PagedResponse, Channel, LinkInfo, Paging, RequestObject } from '../../models';
import { PagingService } from '../../services/paging.service';
import { CHANNEL_PAGING } from '../../app.config';

import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalConfirmComponent } from '../modal-confirm/modal-confirm.component';



@Component({
  selector: 'app-channels',
  templateUrl: './channels.component.html',
  styleUrls: ['./channels.component.css']
})
export class ChannelsComponent implements OnInit {

  subscription: Subscription;

  channels: Channel[] = [];
  selectedId: number;
  paging: Paging = {} as Paging;
  visitedId: number;

  

  constructor(private channelService: ChannelService,
    public router: Router,
    public route: ActivatedRoute,
    private modalService: NgbModal,
    @Inject(CHANNEL_PAGING) private pagingService: PagingService,

  ) { }


  ngOnInit() {

    this.subscription = this.pagingService.requestObject
      .switchMap(value => this.channelService.getChannels(value))
      .subscribe((pagedResponse: PagedResponse<Channel>) => {
        this.channels = pagedResponse.items;
        this.paging = pagedResponse.paging;
        this.visitedId = this.pagingService.currentRequestObject.visitedId;
        
      });
    
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }



  onPage(event: PaginationObject) {
    
    this.pagingService.changeRequestObject({
      pageNumber: event.pageNumber,
      pageSize: event.pageSize
    });

  }

  onFilter(event) {
    
    this.pagingService.changeRequestObject({
      term: event.target.value
    });
  }

  onFilterFocus() {
    
    this.pagingService.changeRequestObject({
      pageNumber: 1
    });
  }

  showDetails(id) {
    this.router.navigate([{
      outlets: {
        primary: ['how','channels',id, 'channel-details']
        
      }
    }]);
  }

  createChannel() {
   
    this.router.navigate([{
      outlets: {
        primary: ['how','channels','channel-add']
      }
    }]);
  }

  editChannel(id) {
    this.router.navigate([{
      outlets: {
        primary: ['how', 'channels',id, 'channel-edit']
        
      }
    }]);
  }

  onDeleteChannel(id) {
    let modal = this.modalService.open(ModalConfirmComponent);
    modal.componentInstance.name = 'Channel';
    modal.result.then((result) => {
      this.onDeleteConfirmation(id);
    }, () => { });
  }

  onDeleteConfirmation(id) {
    this.channelService.deleteChannel(+id)
      .subscribe(result => {
        this.pagingService.changeRequestObject({
          pageNumber: 1
        });
      });
  }

}
