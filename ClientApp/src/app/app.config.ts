import { InjectionToken } from '@angular/core';
import { PagingService } from './services/paging.service';

export const CHANNEL_PAGING = new InjectionToken<PagingService>('ChannelPaging');
export const CUSTOMER_PAGING = new InjectionToken<PagingService>('CustomerPaging');
export const CHAT_PAGING = new InjectionToken<PagingService>('ChatPaging');
