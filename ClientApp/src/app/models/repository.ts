import { OnInit } from "@angular/core";
import { Channel } from './';
import { ChannelService } from "../services/channel.service";
export class Repository implements OnInit {
  private channels: Channel[];

  constructor(private channelSerivce: ChannelService) { }

  ngOnInit() {}

  
}
