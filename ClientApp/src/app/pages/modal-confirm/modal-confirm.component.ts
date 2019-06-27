import { Component, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-confirm',
  templateUrl: './modal-confirm.component.html',
  styleUrls: ['./modal-confirm.component.css']
})
export class ModalConfirmComponent  {
  @Input() question: string;
  @Input() dismissName: string;
  @Input() confirmName: string;


  constructor(public activeModal: NgbActiveModal) { }

  
}
