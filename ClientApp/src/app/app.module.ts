import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgModule, SimpleChange, InjectionToken } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TestApiComponent } from './test-api/test-api.component';
import { SimpleChatComponent } from './simple-chat/simple-chat.component';

import { ApiService } from './services/api.service';
import { LocalStorageService } from './services/local-storage.service';

import { ChannelService } from './services/channel.service';
import { ChannelDetailResolver } from './services/resolvers/channel-detail-resolver.service';
import { ChannelsResolver } from './services/resolvers/channels-resolver.service';

import { CustomerService } from './services/customer.service';
import { CustomerDetailResolver } from './services/resolvers/customer-detail-resolver.service';
import { CustomersResolver } from './services/resolvers/customers-resolver.service';

import { AvatarService } from './services/avatar.service';


import { ChatService } from './services/chat.service';
import { ChatDetailResolver } from './services/resolvers/chat-detail-resolver.service';
import { ChatsResolver } from './services/resolvers/chats-resolver.service';
import { ChatsComponent } from './pages/chats/chats.component';
import { ChatDetailComponent } from './pages/chat-detail/chat-detail.component';
import { ChatEditorComponent } from './pages/chat-editor/chat-editor.component';


import { CustomersOfChannelPipe } from './pipes/customers-of-channel.pipe';

import { ComponentsModule } from './components/components.module';
import { HowComponent } from './pages/how/how.component';
import { ChannelsComponent } from './pages/channels/channels.component';
import { ChannelDetailComponent } from './pages/channel-detail/channel-detail.component';
import { ChannelEditorComponent } from './pages/channel-editor/channel-editor.component';

import { NotFoundComponent } from './pages/not-found/not-found.component';
import { DeleteConfirmationComponent } from './components/delete-confirmation/delete-confirmation.component';
import { CustomersComponent } from './pages/customers/customers.component';
import { CustomerDetailComponent } from './pages/customer-detail/customer-detail.component';
import { CustomerEditorComponent } from './pages/customer-editor/customer-editor.component';
import { PagingService } from './services/paging.service';
import { PagingServiceFactory } from './services/paging-service-factory';

import { CHANNEL_PAGING, CUSTOMER_PAGING, CHAT_PAGING } from './app.config';



import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalConfirmComponent } from './pages/modal-confirm/modal-confirm.component';
import { ModalListComponent } from './pages/modal-list/modal-list.component';



export const ChannelPrefix = new InjectionToken<string>('ChannelPrefix');
export const Channel = 'CHANNEL';

export const CustomerPrefix = new InjectionToken<string>('CustomerPrefix');
export const Customer = 'CUSTOMER';

export const ChatPrefix = new InjectionToken<string>('ChatPrefix');
export const Chat = 'CHAT';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TestApiComponent,
    SimpleChatComponent,
    CustomersOfChannelPipe,
    HowComponent,
    ChannelsComponent,
    ChannelDetailComponent,
    NotFoundComponent,
    ChannelEditorComponent,
    DeleteConfirmationComponent,
    CustomersComponent,
    CustomerDetailComponent,
    CustomerEditorComponent,
    ModalConfirmComponent,
    ModalListComponent,
    ChatsComponent,
    ChatDetailComponent,
    ChatEditorComponent,
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot(),
    ComponentsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'test-api', component: TestApiComponent },
      { path: 'simple-chat', component: SimpleChatComponent },
      {
        path: 'how', component: HowComponent,
        children: [
          {
            path: 'channels',
            children: [
              {
                path: '',
                component: ChannelsComponent,
                data: { title: 'List of Channels' },
              },
              {
                path: ':id/channel-details',
                component: ChannelDetailComponent,
                resolve: {
                  channel: ChannelDetailResolver,
                },
                data: { title: 'Channel Details' }
              },
              {
                path: 'channel-add',
                component: ChannelEditorComponent,
                resolve: {
                  customers: CustomersResolver
                },
                data: { title: 'Add Channel' }

              }, {
                path: ':id/channel-edit',
                component: ChannelEditorComponent,
                resolve: {
                  channel: ChannelDetailResolver,
                  customers: CustomersResolver
                },
                data: { title: 'Edit Channel' }
              },
            ]
          },

          {
            path: 'customers',
            children: [
              {
                path: '',
                component: CustomersComponent,
                data: { title: 'List of Customers' },
              },
              {
                path: ':id/customer-details',
                component: CustomerDetailComponent,
                resolve: {
                  customer: CustomerDetailResolver,
                },
                data: { title: 'Customer Details' }
              },
              {
                path: 'customer-add',
                component: CustomerEditorComponent,
                resolve: {
                  channels: ChannelsResolver
                },
                data: { title: 'Add Customer' }

              }, {
                path: ':id/customer-edit',
                component: CustomerEditorComponent,
                resolve: {
                  customer: CustomerDetailResolver,
                  channels: ChannelsResolver
                },
                data: { title: 'Edit Customer' }
              },
            ]
          },

          {
            path: 'chats',
            children: [
              {
                path: '',
                component: ChatsComponent,
                data: { title: 'List of Chats' },
              },
              {
                path: ':id/chat-details',
                component: ChatDetailComponent,
                resolve: {
                  chat: ChatDetailResolver,
                },
                data: { title: 'Chat Details' }
              },
              {
                path: 'chat-add',
                component: ChatEditorComponent,
                resolve: {
                  channels: ChatsResolver
                },
                data: { title: 'Add Chat' }

              }, {
                path: ':id/chat-edit',
                component: ChatEditorComponent,
                resolve: {
                  customer: ChatDetailResolver,
                  channels: ChatsResolver
                },
                data: { title: 'Edit Chat' }
              },
            ]
          }, 
          
          {
            path: '',
            redirectTo: 'channels',
            pathMatch: 'full'
          }          
        ]
      },
      {
        path: 'delete-confirm',
        component: DeleteConfirmationComponent,
        outlet: 'popup'
      },
      { path: '**', component: NotFoundComponent }
    ])
  ],
  providers: [
    LocalStorageService,
    ApiService,
    ChannelService,
    ChannelDetailResolver,
    ChannelsResolver,
    CustomerService,
    CustomerDetailResolver,
    CustomersResolver,
    PagingService,
    AvatarService,
    ChatService,
    ChatDetailResolver,
    ChatsResolver,
    
    { provide: ChannelPrefix, useValue: Channel },
    { provide: CustomerPrefix, useValue: Customer },
    { provide: ChatPrefix, useValue: Chat },
    {
      provide: CHANNEL_PAGING,
      useFactory: (localStorage, prefix) => { return new PagingService(localStorage, prefix) },
      deps: [LocalStorageService, ChannelPrefix]
    },
    {
      provide: CUSTOMER_PAGING,
      useFactory: (localStorage, prefix) => { return new PagingService(localStorage, prefix) },
      deps: [LocalStorageService, CustomerPrefix]
    },
    {
      provide: CHAT_PAGING,
      useFactory: (localStorage, prefix) => { return new PagingService(localStorage, prefix) },
      deps: [LocalStorageService, ChatPrefix]
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    ModalConfirmComponent,
    ModalListComponent 
  ]
})
export class AppModule { }
