import { Component, Inject, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import { Subscription, BehaviorSubject } from 'rxjs';
import { ChannelService } from '../../services/channel.service';

import { PaginationObject } from '../../components/paginator/pagination-object';
import { PaginatorComponent } from '../../components/paginator/paginator.component';
import { PagedResponse, Channel, LinkInfo, Paging, RequestObject } from '../../models';



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

  

  constructor(private cs: ChannelService,
              public router: Router,
              public route: ActivatedRoute) {}


  ngOnInit() {

    this.subscription = this.cs.requestObject
      .switchMap(value => this.cs.getChannelsPaged(value))
      .subscribe((pagedResponse: PagedResponse<Channel>) => {
        this.channels = pagedResponse.items;
        this.paging = pagedResponse.paging;
        this.visitedId = this.cs.currentRequestObject.visitedId;
        
      });

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }



  onPage(event: PaginationObject) {

    this.cs.changeRequestObject({
      pageNumber: event.pageNumber,
      pageSize: event.pageSize
    });

  }

  onFilter(event) {
    this.cs.changeRequestObject({
      term: event.target.value
    });
  }

  onFilterFocus() {
    this.cs.changeRequestObject({
      pageNumber: 1
    });
  }

  showDetails(id) {
    this.router.navigate(['how/channel-details', id
    ]);
  }

  createChannel() {
    this.router.navigate(['how/channel-add']);
  }

  editChannel(id) {
    this.router.navigate(['how/channel-edit', id
    ]);
  }

  deleteChannel(id) {
    this.cs.deleteChannel(id).subscribe(result =>
      this.cs.changeRequestObject({})
    );
 
  }

}
