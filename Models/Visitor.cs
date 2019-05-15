using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class Visitor
    {
        public long VisitorId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }


        public long? AvatarId { get; set; }
        public Avatar Avatar { get; set; }


        public Chat Chat { get; set; }

        
    }
}
