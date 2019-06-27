using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoustonOnWire.Models;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Lib;

using HoustonOnWire.Models.BindingTargets;

namespace HoustonOnWire.Controllers
{
    [Route("api/channels")]
    public class ChannelValuesController : Controller
    {
        private readonly DataContext context;
        private readonly IUrlHelper urlHelper;

        public ChannelValuesController(DataContext ctx, IUrlHelper urlHelper) {
            this.context = ctx;
            this.urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetChannels")]
        public IActionResult GetChannelsPaged(FilterParams filterParams)
        {
            IQueryable<Channel> query = context.Channels;

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                query = query.Where(channel => channel.Name.ToLower().Contains(filterParams.Term));
            }

            if (filterParams.Related)
            {
                query = query.Include(channel => channel.ChannelCustomers)
                    .ThenInclude(channelCustomers => channelCustomers.Customer)
                    .Select(channel => RemoveChannelCycles(channel));

            }

            var model = new PagedList<Channel>(query, filterParams.PageNumber, filterParams.PageSize, filterParams.Term);
            
            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new PagedOutputModel<Channel>
            {
                Paging = model.GetHeader(),
                Links = model.GetLinkInfos<Channel>(urlHelper),
                Items = model.List
            };
            return Ok(outputModel);
     }

       
        [HttpGet("{id}")]
        public Channel GetChannel(long id)
        {
            Channel channel = context.Channels
                .Include(ch => ch.ChannelCustomers)
                .ThenInclude(channelCustomer => channelCustomer.Customer)
                .FirstOrDefault(ch => ch.ChannelId == id);

            if (channel != null)
                channel = RemoveChannelCycles(channel);

            return channel;
        }

        [HttpPost]
        public IActionResult CreateChannel([FromBody ] ChannelData channelData)
        {
            if (ModelState.IsValid)
            {
                Channel channel = channelData.Channel;
                context.Channels.Add(channel);
                context.SaveChanges();
             
                return Ok(channel.ChannelId);
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceChannel(long id, [FromBody] ChannelData channelData)
        {
            if (ModelState.IsValid)
            {
                Channel channel = context.Set<Channel>()
                    .Include(c => c.ChannelCustomers).First(c => c.ChannelId == id);
                channel.Name = channelData.Channel.Name;
                channel.ChannelCustomers = channelData.ChannelCustomers.Select(cc
                   => new ChannelCustomer
                   {
                       ChannelId = id,
                       CustomerId = cc.CustomerId
                   }).ToList();
                context.SaveChanges();
                return Ok(channel.ChannelId);
            }else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteChannel(long id)
        {
            context.Channels.Remove(new Channel { ChannelId = id });
            context.SaveChanges();
        }

        private Channel RemoveChannelCycles(Channel channel)
        {
            if (channel.ChannelCustomers.Count() > 0)
            {
                foreach (var cc in channel.ChannelCustomers)
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
            return channel;
        }


    }
}
