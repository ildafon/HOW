using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class ChannelCustomer
    {

        public long ChannelId { get; set; }
        public Channel Channel { get; set; }


        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime Received { get; set; }
    }
}
