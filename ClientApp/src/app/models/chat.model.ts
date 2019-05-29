import { Customer } from "./customer.model";
import { Visitor } from "./visitor.model";
import { Message } from "./message.model";

export interface Chat {
  chatId: number;
  isActive: boolean;
  customerFirstResponse: number;
  score: number;

  customer: Customer;
  visitor: Visitor;
  messages: Message[];
  lastMessageId: number;
}
