using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;
using Microsoft.EntityFrameworkCore;

namespace HoustonOnWire.OtherLayers
{
    public class ChannelService : IChannelService
    {
        private DataContext context;

        public ChannelService(DataContext ctx)
        {
            this.context = ctx;
        }

        public PagedList<Channel> GetChannels(FilterParams filterParams) {
            
            IQueryable<Channel> query = context.Channels;

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                query = query.Where(channel => channel.Name.ToLower().Contains(filterParams.Term));
            }

            if (filterParams.Related) { 
                query = query.Include(channel => channel.ChannelCustomers)
                    .ThenInclude(channelCustomers => channelCustomers.Customer)
                    .Select(channel => RemoveChannelCycles(channel));
                
            }
            
            return new PagedList<Channel>(query, filterParams.PageNumber, filterParams.PageSize);
        }

        public Channel GetChannel(long id)
        {
            Channel result = context.Channels
                .Include(channel => channel.ChannelCustomers)
                .ThenInclude(channelCustomer => channelCustomer.Customer)
                .FirstOrDefault(channel => channel.ChannelId == id);

            if (result != null)
                result = RemoveChannelCycles(result);

            return result;
        }

        private Channel RemoveChannelCycles(Channel ch) {
            if (ch.ChannelCustomers.Count() > 0)
            {
                foreach (var cc in ch.ChannelCustomers)
                {
                    cc.Channel = null;
                    cc.Customer = new Customer
                    {
                        CustomerId = cc.Customer.CustomerId,
                        Name = cc.Customer.Name,
                        Email = cc.Customer.Email,
                        Avatar = cc.Customer.Avatar
                    };

                }
            }
            return ch;

        }
    }
}
