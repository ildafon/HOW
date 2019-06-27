import { Visitor } from '../../models';
import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-avatar-username',
  templateUrl: './avatar-username.component.html',
  styleUrls: ['./avatar-username.component.css']
})
export class AvatarUsernameComponent implements OnInit {
  @Input() user: Visitor;
  @Input() currentlySelected: boolean = false ;
  initials: string;

  constructor() { }

  ngOnInit() {
    const words = this.user.name.match(/\b\w/g) || [];

    this.initials = ((words.shift() || '') + (words.pop() || '')).toUpperCase();
  }

  get name() {
    return this.user.name;
  }
}
