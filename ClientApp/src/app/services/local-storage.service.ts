import { Injectable } from '@angular/core';

const APP_PREFIX = 'HOW-';

@Injectable()
export class LocalStorageService {

  constructor() { }


  setItem<T>(key: string, value: T) {
    localStorage.setItem(`${APP_PREFIX}${key}`, JSON.stringify(value));
  }


  getItem<T>(key: string): T {
    let data: any = localStorage.getItem(`${APP_PREFIX}${key}`);
    if (!data) return null;
    let obj: T;

    try {
      obj = <T>JSON.parse(data);
    } catch (error) {
      obj = null;
    }

    return obj;
  }

  removeItem(key: string) {
    localStorage.removeItem(`${APP_PREFIX}${key}`);
  }

}
