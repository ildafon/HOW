import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { PagedResponse, RequestObject, IRequestObject } from '../models';
import { LocalStorageService } from './local-storage.service';



@Injectable()
export class PagingService {
 
  private requestObjestInitial: RequestObject;

  private requestObject$ = new BehaviorSubject<RequestObject>(this.getRequestObjectInitial());

  get currentRequestObject() {
    return this.requestObject$.getValue();
  }

  get requestObject() {
    return this.requestObject$.asObservable();
  }

  constructor(
    private localStorageService: LocalStorageService,
    private prefix: string
  ) { }

  changeRequestObject(reqObj: Object) {
    this.requestObject$.next((<any>Object).assign(this.requestObject$.value, reqObj));
    this.localStorageService.setItem<RequestObject>(`${this.prefix}_REQUEST_OBJECT`, this.currentRequestObject);
  }

  refresh() {
    this.requestObject$.next((<any>Object).assign(this.requestObject$.value, {}));
  }

  private getRequestObjectInitial() {
    return this.localStorageService
      .getItem<RequestObject>(`${this.prefix}_REQUEST_OBJECT`) || new RequestObject;
  }

}
