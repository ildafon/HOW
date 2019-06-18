import { Component, OnInit, Input, Inject } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, NavigationStart } from '@angular/router';
import { ChannelService } from '../../services/channel.service';
import { PagingService } from '../../services/paging.service';
import { filter, skip, distinctUntilChanged } from 'rxjs/operators';
import { CHANNEL_PAGING } from '../../app.config';
import { ModalService } from '../../services/modal.service';

@Component({
  selector: 'app-delete-confirmation',
  templateUrl: './delete-confirmation.component.html',
  styleUrls: ['./delete-confirmation.component.css']
})
export class DeleteConfirmationComponent implements OnInit {

  //id: string;
  private _resolve;
  private _reject;
  

  constructor(
    //private router: Router,
    //private route: ActivatedRoute,
    //private channelService: ChannelService,
    //@Inject(CHANNEL_PAGING) private pagingService: PagingService
    modalService: ModalService
  ) {}

  ngOnInit() {
    //this.route.paramMap.subscribe((params: ParamMap) => {
    //  this.id = params.get("id");
    //  this.cb = params.get("cb");
    //})
  }

  onCancel() {
    //this.closePopup();
  }

  onDelete() {
    //this.cb(this.id);
  }

  closePopup() {
    //this.router.navigate([{ outlets: { popup: null } } ]);
  }

  close() { }

  dismiss() {}
}
