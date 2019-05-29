import { Time } from "@angular/common";
import { Chat } from "./chat.model";

export interface Message {
  messageId: number;
  content: string;
  fromVisitor: boolean;
  received: Time;
  chat: Chat;
}
