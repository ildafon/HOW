import { Avatar } from './avatar.model';
import { Chat } from './chat.model';

export interface Visitor {
  visitorId: number;
  name: string;
  email: string;
  phone: string;
  comment: string;
  avatar: Avatar;
  chat: Chat;
}
