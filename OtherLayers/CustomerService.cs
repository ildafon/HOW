using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;

namespace HoustonOnWire.OtherLayers
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext context;

        public CustomerService(DataContext ctx)
        {
            this.context = ctx;
        }

        public PagedList<Customer> GetCustomers(FilterParams filterParams)
        {
            IQueryable<Customer> query = context.Customers;

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                query = query.Where(customer => customer.Name.ToLower().Contains(filterParams.Term));
            }
            if (filterParams.Related)
            {
                query = query.Include(customer => customer.ChannelCustomers)
                    .ThenInclude(channelCustomers => channelCustomers.Channel)
                    .Include(customer => customer.Avatar)
                    .Include(customer => customer.Chats)
                    .Select(customer => RemoveCustomerCycles(customer));
            }
            return new PagedList<Customer>(query, filterParams.PageNumber, filterParams.PageSize, filterParams.Term);
        }

       

        public Customer GetCustomer(long id)
        {
            Customer result = context.Customers
                .Include(customer => customer.ChannelCustomers)
                .ThenInclude(channelCustomers => channelCustomers.Channel)
                .Include(customer => customer.Avatar)
                .Include(customer => customer.Chats)
                .FirstOrDefault(customer => customer.CustomerId == id);
            if (result != null)
                result = RemoveCustomerCycles(result);


            return result;
        }

        private Customer RemoveCustomerCycles(Customer cus)
        {
            if (cus.ChannelCustomers.Count() > 0)
            {
                foreach(var cc in cus.ChannelCustomers)
                {
                    cc.Customer = null;
                    cc.Channel = new Channel
                    {
                        ChannelId = cc.Channel.ChannelId,
                        Name = cc.Channel.Name
                    };
                }
            }
            if (cus.Chats.Count()> 0)
            {
                foreach (var chat in cus.Chats)
                {
                    chat.Customer = null;
                    chat.Messages = null;
                    chat.Visitor = null;
                    
                }
                //cus.Chats.Select(chat =>
                //{
                //    return new Chat
                //    {
                //        ChatId = chat.ChatId,
                //        IsActive = chat.IsActive,
                //        CustomerFirstResponse = chat.CustomerFirstResponse,
                //        Score = chat.Score,
                //        LastMessageId = chat.LastMessageId
                //    };
                //});
            }
            if (cus.Avatar != null)
            {
                cus.Avatar = new Avatar
                {
                    AvatarId = cus.Avatar.AvatarId,
                    Url = cus.Avatar.Url
                };
            }
            return cus;
        }
    }
}
