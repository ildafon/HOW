import { Component, OnInit, OnDestroy, HostBinding, Inject } from '@angular/core';
import { ChannelService } from '../../services/channel.service';
import { PagingService } from '../../services/paging.service';
import { Channel, PagedResponse, Customer } from '../../models';
import { Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { slideInDownAnimation } from '../../animations';
import { CHANNEL_PAGING } from '../../app.config';
import { Location } from '@angular/common';

export interface IRouterData {
  title: string,
  channel?: Channel,
  customers?: Customer[]
}



@Component({
  selector: 'app-channel-detail',
  templateUrl: './channel-detail.component.html',
  styleUrls: ['./channel-detail.component.css'],
  animations: [slideInDownAnimation]
})
export class ChannelDetailComponent implements OnInit, OnDestroy {
  @HostBinding('@routeAnimation') routeAnimation = true;
  @HostBinding('style.display') display = 'block';
  @HostBinding('style.position') position = 'absolute';

  title: string;
  channel: Channel;
  subscription: Subscription;
  

  constructor(private cs: ChannelService,
              private router: Router,
              private route: ActivatedRoute,
              private location: Location,
              @Inject(CHANNEL_PAGING) private pagingService: PagingService) { }

  ngOnInit() {
    this.subscription = this.route.data.subscribe((data: IRouterData) => {
      this.title = data.title;
      this.channel = data.channel;
      this.pagingService.changeRequestObject({ visitedId: this.channel.channelId })
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  backToChannels() {
    this.router.navigate(['/how/channels']);
  }

  back() {
    this.location.back();
  }

}
