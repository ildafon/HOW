using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;
using HoustonOnWire.Lib;

namespace HoustonOnWire.Models
{
    public class Channel
    {
        public long ChannelId { get; set; }
        public string Name { get; set; }

        public DateTime Received { get; set; }

        public IEnumerable<ChannelCustomer> ChannelCustomers { get; set; }
    
    }


    public class ChannelOutputModel
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<Channel> Items { get; set; }
    }
}
