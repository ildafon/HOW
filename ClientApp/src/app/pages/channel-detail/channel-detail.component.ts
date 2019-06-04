import { Component, OnInit, OnDestroy, HostBinding } from '@angular/core';
import { ChannelService } from '../../services/channel.service';
import { Channel, PagedResponse, Customer } from '../../models';
import { Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { slideInDownAnimation } from '../../animations';

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
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.subscription = this.route.data.subscribe((data: IRouterData) => {
      this.title = data.title;
      this.channel = data.channel;
      this.cs.changeRequestObject({ visitedId: this.channel.channelId })
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  backToChannels() {
    this.router.navigate(['/how/channels']);
  }

}
