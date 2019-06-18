import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Channel } from '../../models';
import { ChannelService } from '../channel.service';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class ChannelsResolver implements Resolve<Channel[]> {
  
  constructor(private channelService: ChannelService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Channel[]> {
    return this.channelService.getChannelsAll();
  }

}
