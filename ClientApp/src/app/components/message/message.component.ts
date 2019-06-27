import { Component, Input, OnChanges } from '@angular/core';
import { Message, Visitor, Customer } from '../../models';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnChanges {

  _user: Visitor | Customer;
  _message: Message;

  @Input('message') message: Message;
  @Input('user') user: Visitor | Customer;

  constructor() { }

  ngOnChanges() {
    console.log("message on change");
    this._user = this.user;
    this._message = this.message;
    
  }

}
