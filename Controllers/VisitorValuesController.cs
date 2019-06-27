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
    [Route("api/visitors")]
    public class VisitorValuesController : Controller
    {
        private readonly DataContext context;
        private readonly IUrlHelper urlHelper;

        public VisitorValuesController(DataContext ctx, IUrlHelper urlHelper)
        {
            context = ctx;
            this.urlHelper = urlHelper;
        }


        [HttpGet(Name = "GetVisitors")]
        public IActionResult GetVisitors(FilterParams filterParams)
        {
            IQueryable<Visitor> query = context.Visitors;

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                query = query.Where(visitor =>
                (visitor.Name.ToLower().Contains(filterParams.Term)) ||
                (visitor.Email.ToLower().Contains(filterParams.Term)) ||
                (visitor.Phone.ToLower().Contains(filterParams.Term)) ||
                (visitor.Comment.ToLower().Contains(filterParams.Term)));
            }

            if (filterParams.Related)
            {
                query = query
                    .Include(visitor => visitor.Avatar)
                    .Select(visitor => RemoveVisitorCycles(visitor));
            }

            var model = new PagedList<Visitor>(query,
                filterParams.PageNumber,
                filterParams.PageSize,
                filterParams.Term);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new PagedOutputModel<Visitor>
            {
                Paging = model.GetHeader(),
                Links = model.GetLinkInfos<Visitor>(urlHelper),
                Items = model.List
            };

            return Ok(outputModel);
        }



        [HttpGet("{id}")]
        public Visitor GetVisitor(long id)
        {
            Visitor visitor = context.Visitors
                .Include(v => v.Avatar)
                .FirstOrDefault(v => v.VisitorId == id);
                

            if (visitor != null){
                visitor = RemoveVisitorCycles(visitor);
            }
            return visitor;
        }


        [HttpPost]
        public IActionResult CreateVisitor([FromBody] VisitorData visitorData)
        {
            if (ModelState.IsValid)
            {
                Visitor visitor = visitorData.Visitor;
                if (visitor.Avatar != null && visitor.Avatar.AvatarId != 0)
                {
                    context.Attach(visitor.Avatar);
                }
                context.Visitors.Add(visitor);
                context.SaveChanges();
                return Ok(visitor.VisitorId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVisitor(long id, [FromBody] VisitorData visitorData)
        {
            if (ModelState.IsValid)
            {
                Visitor visitor = context.Visitors
                    .First(v => v.VisitorId == id);
                visitor.Name = visitorData.Name;
                visitor.Email = visitorData.Email;
                visitor.Phone = visitorData.Phone;
                visitor.Comment = visitorData.Comment;

                if (visitorData.Visitor.Avatar != null && 
                    visitorData.Visitor.Avatar.AvatarId != 0)
                {
                    visitor.Avatar = visitorData.Visitor.Avatar;
                    context.Attach(visitor.Avatar);
                }
                context.SaveChanges();
                return Ok(visitor.VisitorId);

            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteVisitor(long id)
        {
            if (id > 0)
            {
                context.Remove(new Visitor { VisitorId = id });
                context.SaveChanges();
            }
        }

        private Visitor RemoveVisitorCycles(Visitor visitor )
        {
            var lVisitor = new Visitor {
                VisitorId = visitor.VisitorId,
                Name = visitor.Name,
                Email = visitor.Email,
                Phone = visitor.Phone,
                Comment = visitor.Comment,
            };

            if (visitor.Avatar != null)
            {
                lVisitor.Avatar = new Avatar
                {
                    AvatarId = visitor.Avatar.AvatarId,
                    Url = visitor.Avatar.Url
                };
            }

            return lVisitor;
        }


        
    }
}
