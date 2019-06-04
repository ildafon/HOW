using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;
using HoustonOnWire.OtherLayers;
using HoustonOnWire.Models.BindingTargets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoustonOnWire.Controllers
{
    [Route("api/customers")]
    public class CustomerValuesController : Controller
    {
        private DataContext context;
        private readonly ICustomerService customerService;
        private readonly IUrlHelper urlHelper;

        public CustomerValuesController(DataContext ctx, ICustomerService service,
            IUrlHelper urlHelper)
        {
            this.context = ctx;
            this.customerService = service;
            this.urlHelper = urlHelper;
        }

        [HttpGet(Name ="GetCustomers")]
        public IActionResult Get(FilterParams filterParams)
        {
            var model = customerService.GetCustomers(filterParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new CustomerOutputModel {
                Paging = model.GetHeader(),
                Links = GetLinks(model),
                Items = model.List
            };
            return Ok(outputModel);
        }

        [HttpGet("all")]
        public IEnumerable<Customer> GetAll()
        {
            IQueryable<Customer> query = context.Customers;
            return query;
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(long id)
        {
            return customerService.GetCustomer(id);
        }


        private List<LinkInfo> GetLinks(PagedList<Customer> list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink("GetCustomers", list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("GetCustomers", list.PageNumber, list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("GetCustomers", list.NextPageNumber, list.PageSize, "nextPage", "GET"));
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
