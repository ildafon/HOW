import { BrowserModule } from '@angular/platform-browser';
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
import { CustomersOfChannelPipe } from './pipes/customers-of-channel.pipe';

import { ComponentsModule } from './components/components.module';
import { HowComponent } from './pages/how/how.component';
import { ChannelsComponent } from './pages/channels/channels.component';
import { ChannelDetailComponent } from './pages/channel-detail/channel-detail.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

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
    NotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
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
          { path: '', redirectTo: 'channels', pathMatch: 'full' },
          { path: 'channel/:id', component: ChannelDetailComponent },
          {
            path: 'channels', component: ChannelsComponent,
            //children: [{ path: ':id', component: ChannelDetailComponent }],
            data: { title: "Channels" }
          },
          
          
        ]
      },
      { path: '**', component: NotFoundComponent }
    ])
  ],
  providers: [ApiService, ChannelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
