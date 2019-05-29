import { Avatar } from './avatar.model';
import { Chat } from './chat.model';
import { Channel } from './channel.model';

export interface Customer {
  customerId: number;
  name: string;
  email: string;
  avatar: Avatar;
  channels: Channel[];
  chats: Chat[];
}
