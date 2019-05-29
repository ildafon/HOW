import { Component, OnInit, OnDestroy } from '@angular/core';
import { ChannelService } from '../../services/channel.service';
import { Channel } from '../../models';
import { Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-channel-detail',
  templateUrl: './channel-detail.component.html',
  styleUrls: ['./channel-detail.component.css']
})
export class ChannelDetailComponent implements OnInit, OnDestroy {
  channel: Channel;
  subscription: Subscription;
  id: string;
  page: string;
  term: string;
  pageSize: string;

  constructor(private channelService: ChannelService,
              private router: Router,
              private route: ActivatedRoute) {}

  ngOnInit() {

    //this.subscription = this.route.paramMap.pipe(
    //  switchMap((params: ParamMap) =>
    //    this.channelService.getChannel(+params.get('id')))
    //  )
    //  .subscribe(result => this.channel = result);

    this.id = this.route.snapshot.paramMap.get("id");
    this.page = this.route.snapshot.paramMap.get("page");
    this.term = this.route.snapshot.paramMap.get("term");
    this.pageSize = this.route.snapshot.paramMap.get("psize");

    this.channelService.getChannel(+this.id)
      .subscribe(result => this.channel = result);
  }

  ngOnDestroy() {
    //this.subscription.unsubscribe();
  }

  backToChannels() {
    this.router.navigate(['/how/channels',
      {
        id: this.id,
        page: this.page,
        term: this.term,
        psize: this.pageSize
      }]);
  }

}
