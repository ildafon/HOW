import { Component, OnInit } from '@angular/core';

export interface IMenuItem {
  url: string;
  label: string;
}

const menuItems: IMenuItem[] = [{ label: 'Channels', url: '/how/channels' },
                                { label: 'Customers', url: '/how/customers' },
                                { label: 'Chats', url: '/how/chats' },
                                { label: 'Messages', url: '/how/messages' }];

@Component({
  selector: 'app-how',
  templateUrl: './how.component.html',
  styleUrls: ['./how.component.css']
})
export class HowComponent implements OnInit {
  menuItems = menuItems;

  constructor() { }

  ngOnInit() {
  }

}
