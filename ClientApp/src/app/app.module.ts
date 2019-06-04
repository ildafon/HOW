import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgModule, SimpleChange } from '@angular/core';
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
import { ChannelService } from './services/channel.service';
import { CustomerService } from './services/customer.service';
import { CustomersOfChannelPipe } from './pipes/customers-of-channel.pipe';

import { ComponentsModule } from './components/components.module';
import { HowComponent } from './pages/how/how.component';
import { ChannelsComponent } from './pages/channels/channels.component';
import { ChannelDetailComponent } from './pages/channel-detail/channel-detail.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { ChannelEditorComponent } from './pages/channel-editor/channel-editor.component';
import { ChannelDetailResolver } from './services/channel-detail-resolver.service';
import { CustomersResolverService } from './services/customers-resolver.service';

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
    ChannelEditorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
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
            component: ChannelsComponent,
            data: {title: 'List of Channels'}
          }, 
          {
            path: 'channel-details/:id',
            component: ChannelDetailComponent,
            resolve: {
              channel: ChannelDetailResolver,
            },
            data: {title: 'Channel Details'}
          },
          {
            path: 'channel-add',
            component: ChannelEditorComponent,
            resolve: {
              customers: CustomersResolverService
            },
            data: { title: 'Add Channel' }
            
          }, {
            path: 'channel-edit/:id',
            component: ChannelEditorComponent,
            resolve: {
              channel: ChannelDetailResolver,
              customers: CustomersResolverService 
            },
            data: {title: 'Edit Channel'}
          },
          {
            path: '',
            redirectTo: 'channels',
            pathMatch: 'full'
          }          
        ]
      },
      { path: '**', component: NotFoundComponent }
    ])
  ],
  providers: [
    ApiService,
    ChannelService,
    ChannelDetailResolver,
    CustomerService,
    CustomersResolverService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
