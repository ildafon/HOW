using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class Message
    {
        public long MessageId { get; set; }

        
        public string Content { get; set; }
        public bool FromVisitor { get; set; }
        

        public long ChatId { get; set; }
        public Chat Chat { get; set; }

        public DateTime Received { get; set; }
    }
}
