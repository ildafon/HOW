import { LocalStorageService } from './local-storage.service';
import { PagingService } from './paging.service';


export function PagingServiceFactory() {
  return (localStorage: LocalStorageService, prefix) => {
    return new PagingService(localStorage, prefix);
  }
}
