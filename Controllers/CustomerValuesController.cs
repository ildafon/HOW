using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;
using HoustonOnWire.Models.BindingTargets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoustonOnWire.Controllers
{
    [Route("api/customers")]
    public class CustomerValuesController : Controller
    {
        private readonly DataContext context;
        
        private readonly IUrlHelper urlHelper;

        public CustomerValuesController(DataContext ctx, IUrlHelper urlHelper)
        {
            this.context = ctx;
            this.urlHelper = urlHelper;
        }

        [HttpGet(Name ="GetCustomers")]
        public IActionResult GetCustomers(FilterParams filterParams)
        {
            IQueryable<Customer> query = context.Customers;

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                query = query.Where(customer => (customer.Name.ToLower().Contains(filterParams.Term)) ||
                                                (customer.Email.ToLower().Contains(filterParams.Term)));
            }
            if (filterParams.Related)
            {
                query = query.Include(customer => customer.ChannelCustomers)
                    .ThenInclude(channelCustomers => channelCustomers.Channel)
                    .Include(customer => customer.Avatar)
                    .Include(customer => customer.Chats)
                    .Select(customer => RemoveCustomerCycles(customer));
            }


            var model = new PagedList<Customer>(query, filterParams.PageNumber, filterParams.PageSize, filterParams.Term);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new CustomerOutputModel {
                Paging = model.GetHeader(),
                //Links = GetLinks(model),
                Links = model.GetLinkInfos<Customer>(urlHelper),
                Items = model.List
            };
            return Ok(outputModel);
        }

        
        [HttpGet("{id}")]
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

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                Customer customer = customerData.Customer;
                if (customer.Avatar != null && customer.Avatar.AvatarId != 0)
                {
                    context.Attach(customer.Avatar);
                }
                context.Customers.Add(customer);
                context.SaveChanges();
                return Ok(customer.CustomerId);
            }else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(long id, [FromBody] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                Customer customer = context.Set<Customer>()
                    .Include(c => c.ChannelCustomers)
                    .First(c => c.CustomerId == id);
                customer.Name = customerData.Customer.Name;
                customer.Email = customerData.Customer.Email;
                if (customerData.Customer.Avatar != null && customerData.Customer.Avatar.AvatarId != 0)
                {
                    customer.Avatar = customerData.Customer.Avatar;
                    context.Attach(customer.Avatar);
                }

                customer.ChannelCustomers = customerData.ChannelCustomers.Select(cc => new ChannelCustomer
                {
                    CustomerId = id,
                    ChannelId = cc.ChannelId
                }).ToList();
                context.SaveChanges();


                return Ok(customer.CustomerId);
            }else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(long id)
        {
            if (id > 0)
            {
                context.Remove(new Customer { CustomerId = id });
                context.SaveChanges();
            }
        }

        //private List<LinkInfo> GetLinks(PagedList<Customer> list)
        //{
        //    var links = new List<LinkInfo>();

        //    if (list.HasPreviousPage)
        //        links.Add(CreateLink("GetCustomers", list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

        //    links.Add(CreateLink("GetCustomers", list.PageNumber, list.PageSize, "self", "GET"));

        //    if (list.HasNextPage)
        //        links.Add(CreateLink("GetCustomers", list.NextPageNumber, list.PageSize, "nextPage", "GET"));
        //    return links;
        //}

        //private LinkInfo CreateLink(string routeName, int pageNumber, int pageSize,
        //    string rel, string method)
        //{
        //    return new LinkInfo
        //    {
        //        Href = urlHelper.Link(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
        //        Rel = rel,
        //        Method = method
        //    };
        //}

        private Customer RemoveCustomerCycles(Customer cus)
        {
            if (cus.ChannelCustomers.Count() > 0)
            {
                foreach (var cc in cus.ChannelCustomers)
                {
                    cc.Customer = null;
                    cc.Channel = new Channel
                    {
                        ChannelId = cc.Channel.ChannelId,
                        Name = cc.Channel.Name
                    };
                }
            }
            if (cus.Chats.Count() > 0)
            {
                foreach (var chat in cus.Chats)
                {
                    chat.Customer = null;
                    chat.Messages = null;
                    chat.Visitor = null;
                }

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
