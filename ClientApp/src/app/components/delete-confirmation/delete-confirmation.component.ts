import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, NavigationStart } from '@angular/router';
import { ChannelService } from '../../services/channel.service';
import { filter, skip, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-delete-confirmation',
  templateUrl: './delete-confirmation.component.html',
  styleUrls: ['./delete-confirmation.component.css']
})
export class DeleteConfirmationComponent implements OnInit {

  id: string;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private channelService: ChannelService) {
    
  }

        

    

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.id = params.get("id");
    })
  }

  onCancel() {
    this.closePopup();
  }

  onDelete() {
    this.channelService.deleteChannel(+this.id)
      .subscribe(result => {
        this.channelService.changeRequestObject({
          pageNumber: 1
        });
        this.closePopup();
      });
  }

  closePopup() {
    this.router.navigate([{ outlets: { popup: null } } ]);
  }
}
