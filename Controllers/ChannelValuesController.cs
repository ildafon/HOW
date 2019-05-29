using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoustonOnWire.Models;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Lib;
using HoustonOnWire.OtherLayers;

namespace HoustonOnWire.Controllers
{
    [Route("api/channels")]
    public class ChannelValuesController : Controller
    {
        private DataContext context;
        private readonly IChannelService service;
        private readonly IUrlHelper urlHelper;

        public ChannelValuesController(DataContext ctx, IChannelService service,
            IUrlHelper urlHelper) {
            this.context = ctx;
            this.service = service;
            this.urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetChannels")]
        public IActionResult Get(FilterParams filterParams)
        {
            System.Console.WriteLine($"In ChannelValueController in Get Action {filterParams.PageNumber}");
            var model = service.GetChannels(filterParams);

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
            Channel result = context.Channels
                .Include(c => c.ChannelCustomers).ThenInclude(cc => cc.Customer)
                .FirstOrDefault(c => c.ChannelId == id);
            
            if (result != null)
                if (result.ChannelCustomers.Count() > 0 )
                   foreach( var cc in result.ChannelCustomers)
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
                    
            return result;

        }

        //[HttpGet]
        //public IEnumerable<Channel> GetChannels(bool related = false)
        //{
        //    IQueryable<Channel> query = context.Channels;
        //    if (related)
        //    {
        //        query = query.Include(ch => ch.ChannelCustomers).ThenInclude(cc => cc.Customer);
        //        List<Channel> data = query.ToList();
        //        data.ForEach(ch =>
        //        {
        //            if (ch.ChannelCustomers.Count() > 0)
        //            {
        //                foreach (var cc in ch.ChannelCustomers)
        //                {
        //                    cc.Channel = null;
        //                    cc.Customer = new Customer
        //                    {
        //                        CustomerId = cc.Customer.CustomerId,
        //                        Name = cc.Customer.Name,
        //                        Email = cc.Customer.Email,
        //                        Avatar = cc.Customer.Avatar
        //                    };

        //                }
        //            }
        //        });
        //        return data;
        //    }
        //    else
        //    {
        //        return query;
        //    }
        //}




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
