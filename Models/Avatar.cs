using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class Avatar
    {
        public long AvatarId { get; set; }

        public string Url { get; set; }

        public Visitor Visitor { get; set; }
        public Customer Customer { get; set; }
    }
}
