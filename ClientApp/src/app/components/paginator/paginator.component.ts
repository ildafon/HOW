import { Component, OnInit, EventEmitter, Input, Output, Inject} from '@angular/core';
import { PaginationObject } from './pagination-object';
import { ChannelService } from '../../services/channel.service';
import { PagingService } from '../../services/paging.service';
import { CHANNEL_PAGING } from '../../app.config';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styles: [
    `
    input[type = number] { width: 80px; }
    .mb-2           {margin-bottom: 10px;}

    `
  ]
})
export class PaginatorComponent implements OnInit {

  private paginationObject = new PaginationObject();

  @Input() totalPages: number;
  @Input() pageNumber: number;
  @Input() pageSize: number;

  @Output() page: EventEmitter<PaginationObject> = new EventEmitter<PaginationObject>();

 


  constructor(private cs: ChannelService,
    @Inject(CHANNEL_PAGING)  private pagingService: PagingService) { }

  ngOnInit() {
    this.pagingService.requestObject.subscribe(reqobj => this.pageNumber = reqobj.pageNumber);
   
  }
 
  get pageNumbers(): number[] {
    return Array(this.totalPages).fill(0).map((x, i) => i + 1);
  }

  onPageChange(pageNum: number) {
    if (pageNum == this.pageNumber) return;
    if (pageNum > 0 && pageNum <= this.totalPages) {
      this.paginationObject.pageNumber = pageNum;
      this.paginationObject.pageSize = this.pageSize;
      this.page.emit(this.paginationObject);
    }
    
  }

  onPageSizeChange(pageSize: number) {
    if (pageSize == this.pageSize) return;
    if (pageSize >= 0) {
      this.paginationObject.pageSize = pageSize;
      this.paginationObject.pageNumber = 1;
      this.page.emit(this.paginationObject);
    }
  }

}
