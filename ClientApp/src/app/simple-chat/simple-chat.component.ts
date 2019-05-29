import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';



@Component({
  selector: 'app-simple-chat',
  templateUrl: './simple-chat.component.html',
  styleUrls: ['./simple-chat.component.css']
})
export class SimpleChatComponent implements OnInit {

  private _hubConnection: HubConnection | undefined;

  message: string = '';
  messages: string[] = [];

  hub: HubConnection;

  constructor() { }

  public sendMessage(): void {
    const data = `Sent: ${this.message}`;

    if (this._hubConnection) {
      this._hubConnection.invoke("Send", data);
    }

    this.messages.push(data);
    

  }

  ngOnInit() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44328/simplehub')
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this._hubConnection.start().catch(err => console.error(err.toString()));

    this._hubConnection.on('SendMessage', (data: any) => {
      const received = `Received: ${data}`;
      this.messages.push(received);
    });

    this.hub = this._hubConnection;
  }

}
