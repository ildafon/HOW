using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class Chat
    {
        public long ChatId { get; set; }

        public bool IsActive { get; set; }
        public DateTime CustomerFirstResponse { get; set; }
        public int Score { get; set; }


        public long? CustomerId { get; set; }
        public Customer Customer { get; set; }


        public long VisitorId { get; set; }
        public Visitor Visitor { get; set; }


        public List<Message> Messages { get; set; }

        public long? LastMessageId { get; set; }

        public DateTime Received { get; set; }
    }
}
