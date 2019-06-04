import { Component, Inject, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';


import { Observable } from 'rxjs/Observable';
import { Subscription, BehaviorSubject } from 'rxjs';
import { ChannelService } from '../services/channel.service';

import { PaginationObject } from '../components/paginator/pagination-object';
import { PaginatorComponent } from '../components/paginator/paginator.component';
import { PagedResponse, Channel, LinkInfo, Paging, RequestObject } from '../models';

@Component({
  templateUrl: './test-api.component.html'
})
export class TestApiComponent implements OnInit, OnDestroy {
  subscription: Subscription;

  channels: Channel[] = [];
  paging: Paging = {} as Paging;
  links: LinkInfo[] = [];

  filterParam$: BehaviorSubject<RequestObject> = new BehaviorSubject(new RequestObject);


  constructor(private channelsService: ChannelService) {  }

  

  ngOnInit() {

    this.subscription = this.filterParam$
      .switchMap(value => this.channelsService.getChannelsPaged(value))
      .subscribe((pagedResponse: PagedResponse<Channel>) => {
        this.channels = pagedResponse.items;
        this.paging = pagedResponse.paging;
        this.links = pagedResponse.links;
        console.log("filterParam changed", pagedResponse);
      });
          
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }



  onPage(event: PaginationObject) {
    
    this.filterParam$.next(Object.assign(this.filterParam$.value, {
      pageNumber: event.pageNumber,
      pageSize: event.pageSize
    }));
  }

  onFilter(event) {
    console.log(event.target.value);
    this.filterParam$.next(Object.assign(this.filterParam$.value, {
      term: event.target.value
    }));
  }
  
}


