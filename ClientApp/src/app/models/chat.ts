import { Customer, Visitor, Message } from ".";

export class Chat {
  constructor(
    public chatId?: number,
    public isActive?: boolean,
    public customerFirstResponse?: number,
    public score?: number,
    public lastMessageId?: number,
    public lastMessage?: Message,

    public customer?: Customer,
    public visitor?: Visitor,
    public messages?: Message[],
    ) { }
}
