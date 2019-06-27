using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;
using HoustonOnWire.Models.BindingTargets;


namespace HoustonOnWire.Controllers
{
    [Route("api/chats")]
    public class ChatValuesController : Controller
    {
        private readonly DataContext context;
        private readonly IUrlHelper urlHelper;

        public ChatValuesController(DataContext ctx, IUrlHelper urlHelper)
        {
            this.context = ctx;
            this.urlHelper = urlHelper;
        }


        [HttpGet(Name = "GetChats")]
        public IActionResult GetChats(FilterParams filterParams)
        {
            IQueryable<Chat> query = context.Chats;

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                query = query.Where(chat =>
                (chat.Visitor.Name.ToLower().Contains(filterParams.Term)) ||
                (chat.Visitor.Email.ToLower().Contains(filterParams.Term)) ||
                (chat.Visitor.Phone.ToLower().Contains(filterParams.Term)) ||
                (chat.Visitor.Comment.ToLower().Contains(filterParams.Term)) ||
                (chat.Customer.Name.ToLower().Contains(filterParams.Term)) ||
                (chat.Customer.Email.ToLower().Contains(filterParams.Term)));
            }

            if (filterParams.Related)
            {
                query = query
                    .Include(c => c.Visitor).ThenInclude(v => v.Avatar)
                    .Include(c => c.Customer).ThenInclude(c => c.Avatar)
                    .Include(c => c.Messages)
                    .Select(c => RemoveChatListCycles(c));
            }

            var model = new PagedList<Chat>(query,
                filterParams.PageNumber, filterParams.PageSize, filterParams.Term);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new PagedOutputModel<Chat>
            {
                Paging = model.GetHeader(),
                Links = model.GetLinkInfos<Chat>(urlHelper),
                Items = model.List
            };
            return Ok(outputModel);
        }

        [HttpGet("{id}")]
        public Chat GetChat(long id)
        {
            Chat chat = context.Chats
                    .Include(c => c.Visitor).ThenInclude(v => v.Avatar)
                    .Include(c => c.Customer).ThenInclude(c => c.Avatar)
                    .Include(c => c.Messages)
                    .FirstOrDefault(c => c.ChatId == id);
            if (chat != null){
                chat = RemoveChatDetailCycles(chat);
            }
            return chat;
        }

        private Chat RemoveChatListCycles (Chat chat)
        {
            var lChat = new Chat
            {
                ChatId = chat.ChatId,
                IsActive = chat.IsActive,
                Score = chat.Score,
                CustomerFirstResponse = chat.CustomerFirstResponse
            };

            if (chat.Visitor != null)
            {
                lChat.Visitor = new Visitor
                {
                    VisitorId = chat.Visitor.VisitorId,
                    Name = chat.Visitor.Name,
                    Email = chat.Visitor.Email,
                    Phone = chat.Visitor.Phone,
                    Comment = chat.Visitor.Comment,
                    Avatar = new Avatar
                    {
                        AvatarId = chat.Visitor.Avatar.AvatarId,
                        Url = chat.Visitor.Avatar.Url
                    }
                };
                lChat.VisitorId = chat.Visitor.VisitorId;
            }

            if (chat.Messages != null)
            {
                var last = chat.Messages.Last(m => m.ChatId == chat.ChatId);

                lChat.LastMessage = new Message
                {
                    Content = last.Content,
                    MessageId = last.MessageId,
                    FromVisitor = last.FromVisitor,
                    ChatId = last.ChatId
                };
            }

            return lChat;
        }

        private Chat RemoveChatDetailCycles(Chat chat)
        {
            var lChat = new Chat
            {
                ChatId = chat.ChatId,
                IsActive = chat.IsActive,
                Score = chat.Score,
                CustomerFirstResponse = chat.CustomerFirstResponse
            };

            if (chat.Visitor != null)
            {
                lChat.Visitor = new Visitor
                {
                    VisitorId = chat.Visitor.VisitorId,
                    Name = chat.Visitor.Name,
                    Email = chat.Visitor.Email,
                    Phone = chat.Visitor.Phone,
                    Comment = chat.Visitor.Comment,
                    Avatar = new Avatar
                    {
                        AvatarId = chat.Visitor.Avatar.AvatarId,
                        Url = chat.Visitor.Avatar.Url
                    }
                };
                lChat.VisitorId = chat.Visitor.VisitorId;
            }

            if (chat.Customer != null)
            {
                lChat.Customer = new Customer {
                    CustomerId = chat.Customer.CustomerId,
                    Name = chat.Customer.Name,
                    Email = chat.Customer.Email,
                    Avatar = new Avatar
                    {
                        AvatarId = chat.Customer.Avatar.AvatarId,
                        Url = chat.Customer.Avatar.Url
                    }
                };
            }

            if (chat.Messages != null)
            {
                lChat.Messages = chat.Messages.Select(m => new Message
                {
                    MessageId = m.MessageId,
                    Content = m.Content,
                    FromVisitor = m.FromVisitor,
                    ChatId = m.ChatId,
                    Received = m.Received
                }).ToList<Message>();


                var last = chat.Messages.Last(m => m.ChatId == chat.ChatId);
                
                lChat.LastMessage = new Message {
                    Content = last.Content,
                    MessageId = last.MessageId,
                    FromVisitor = last.FromVisitor,
                    ChatId = last.ChatId
                };

                lChat.LastMessageId = last.MessageId;

                    
                
            }

            //if (chat.LastMessageId != null)
            //{
            //    var lMessage = context.Messages
            //        .First(m => m.MessageId == chat.LastMessageId);

            //    lChat.LastMessage = new Message
            //    {
            //        MessageId = lMessage.MessageId,
            //        Content = lMessage.Content
            //    };
            //}
            return lChat;
        }
    }
}
