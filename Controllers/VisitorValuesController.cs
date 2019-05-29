using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;


namespace HoustonOnWire.Controllers
{
    [Route("api/visitors")]
    public class VisitorValuesController : Controller
    {
        private DataContext context;

        public VisitorValuesController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Visitor GetVisitor(long id)
        {
            return context.Visitors.Find(id);
        }
    }
}
