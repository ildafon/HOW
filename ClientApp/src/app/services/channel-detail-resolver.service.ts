import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Channel } from "../models";
import { ChannelService } from "./channel.service";
import { Observable } from "rxjs";
import { take, map } from "rxjs/operators";
import { Injectable } from "@angular/core";

@Injectable()
export class ChannelDetailResolver implements Resolve<Channel> {
  constructor(private cs: ChannelService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Channel> {
    let id = route.paramMap.get("id");
    
    return this.cs.getChannel(+id);
  }
}
