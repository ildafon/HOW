import { Time } from "@angular/common";
import { Chat } from "./";



export class Message {
  constructor(
    public messageId?: number,
    public content?: string,
    public fromVisitor?: boolean,
    public received?: Time,
    public chat?: Chat
  ) { }
}
