import { Injectable, ApplicationRef } from '@angular/core';
import { ViewContainerRef, TemplateRef, ElementRef, ViewRef, Injector, ComponentFactoryResolver, ViewChild } from '@angular/core';
import { DeleteConfirmationComponent } from '../components/delete-confirmation/delete-confirmation.component';



@Injectable()
export class ModalService {

  @ViewChild('popup', { read: ViewContainerRef }) vc: ViewContainerRef;

  private _resolve: (result?: any) => void;
  private _reject: (reason?: any) => void;

  result: Promise<any>;

  constructor(
    private injector: Injector,
    private r: ComponentFactoryResolver
  ) {

    this.result = new Promise<any>((resolve, reject) => {
      this._resolve = resolve;
      this._reject = reject;
    });

  }

  open(content: TemplateRef<any>): Promise<any> {
    let view = content.createEmbeddedView(null);
    this.vc.insert(view);
    return this.result;
  }

  close() {
    this._resolve();
  }

  dismiss() {
    this._reject();
  }


}
