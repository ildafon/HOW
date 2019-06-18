import { Customer, Visitor, Message } from ".";





export class Chat {
  constructor(
    public chatId?: number,
    public isActive?: boolean,
    public customerFirstResponse?: number,
    public score?: number,

    public customer?: Customer,
    public visitor?: Visitor,
    public messages?: Message[],
    public lastMessageId?: number

  ) { }
}
