using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoustonOnWire.Models;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Lib;
using HoustonOnWire.OtherLayers;
using HoustonOnWire.Models.BindingTargets;

namespace HoustonOnWire.Controllers
{
    [Route("api/channels")]
    public class ChannelValuesController : Controller
    {
        private DataContext context;
        private readonly IChannelService channelService;
        private readonly IUrlHelper urlHelper;

        public ChannelValuesController(DataContext ctx, IChannelService service,
            IUrlHelper urlHelper) {
            this.context = ctx;
            this.channelService = service;
            this.urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetChannels")]
        public IActionResult Get(FilterParams filterParams)
        {
            //System.Console.WriteLine($"In ChannelValueController in Get Action {filterParams.PageNumber}");
            var model = channelService.GetChannels(filterParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new ChannelOutputModel
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model),
                Items = model.List
            };
            return Ok(outputModel);
     }

       
        [HttpGet("{id}")]
        public Channel GetChannel(long id)
        {
            return channelService.GetChannel(id);
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


        private List<LinkInfo> GetLinks(PagedList<Channel> list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink("GetChannels", list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("GetChannels", list.PageNumber, list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("GetChannels", list.NextPageNumber, list.PageSize, "nextPage", "GET"));
            return links;
        }

        private LinkInfo CreateLink(string routeName, int pageNumber, int pageSize,
            string rel, string method)
        {
            return new LinkInfo
            {
                Href = urlHelper.Link(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }

        
    }
}
