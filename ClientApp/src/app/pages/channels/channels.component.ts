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
  selectedId: string;
  paging: Paging = {} as Paging;
  links: LinkInfo[] = [];

  filterParam$: BehaviorSubject<RequestObject> = new BehaviorSubject(new RequestObject);
  get term():string  {
    return this.filterParam$.value.term;
  }

  set term(t: string) {
    this.filterParam$.next(Object.assign(this.filterParam$.value, { term: t }));
  }

  get page(): number {
    return this.filterParam$.value.pageNumber;
  }

  

  constructor(private channelsService: ChannelService,
              public router: Router,
              public route: ActivatedRoute)
  {
    
  }



  ngOnInit() {

    this.subscription = this.filterParam$
      .switchMap(value => this.channelsService.getChannels(value))
      .subscribe((pagedResponse: PagedResponse<Channel>) => {
        this.channels = pagedResponse.items;
        this.paging = pagedResponse.paging;
        this.links = pagedResponse.links;
        console.log("filterParam changed", pagedResponse);
      });
    this.route.paramMap
      .subscribe(params => {
        console.log("page=", params.get("page"));
        if (params.get("id") && (params.get("page")!=null)) {
          this.filterParam$.next(Object.assign(this.filterParam$.value, {
            pageNumber: params.get("page"),
            term: params.get("term"),
            pageSize: params.get("psize")
          }));
          this.selectedId = params.get("id");
        }
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
    
    this.filterParam$.next(Object.assign(this.filterParam$.value, {
      term: event.target.value
    }));
  }

  onFilterFocus() {
    this.filterParam$.next(Object.assign(this.filterParam$.value, {
      pageNumber: 1  
    }));
  }

  showDetails(id) {
    this.router.navigate(['how/channel-details', id, {
      page: this.filterParam$.value.pageNumber,
      term: this.filterParam$.value.term,
      psize: this.filterParam$.value.pageSize
    }]);
  }

  createChannel() {
    this.router.navigate(['how/channel-add']);
  }

  editChannel(id) {
    this.router.navigate(['how/channel-edit', id]);
  }

  deleteChannel(id) {
    this.channelsService.deleteChannel(id).subscribe(result =>
        this.filterParam$.next(Object.assign(this.filterParam$.value, this.filterParam$.value))
    );
 
  }

}
