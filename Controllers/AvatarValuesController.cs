using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;
using HoustonOnWire.Models.BindingTargets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoustonOnWire.Controllers
{
    [Route("api/avatars")]
    public class AvatarValuesController : Controller
    {
        private readonly DataContext context;
        public AvatarValuesController(DataContext ctx)
        {
            this.context = ctx;
        }


        // GET: api/avatars
        [HttpGet]
        public IEnumerable<Avatar> Get()
        {
            IQueryable<Avatar> query = context.Avatars;
            return query;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Avatar Get(long id)
        {
           
                Avatar result = context.Avatars.Find(id);
                return result;
           
        }

        
        [HttpPost]
        public IActionResult Create([FromBody]AvatarData avatarData)
        {
            if (ModelState.IsValid)
            {
                Avatar avatar = avatarData.Avatar;
                context.Avatars.Add(avatar);
                context.SaveChanges();
                return Ok(avatar);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]AvatarData avatarData)
        {
            if (ModelState.IsValid)
            {
                Avatar avatar = context.Set<Avatar>().First(a => a.AvatarId == id);
                avatar.Url = avatarData.Avatar.Url;
                context.SaveChanges();
                return Ok(avatar.AvatarId);
            }else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0)
            {
                context.Avatars.Remove(new Avatar { AvatarId = id });
                context.SaveChanges();
            }
        }
    }
}
