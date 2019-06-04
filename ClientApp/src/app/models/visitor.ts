import { Avatar, Chat } from './';



export class Visitor {
  constructor(
    public visitorId?: number,
    public name?: string,
    public email?: string,
    public phone?: string,
    public comment?: string,
    public avatar?: Avatar,
    public chat?: Chat
  ) { }
}
