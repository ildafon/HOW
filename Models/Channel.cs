﻿using System;
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

        public IEnumerable<ChannelCustomer> ChannelCustomers { get; set; }

        public DateTime Received { get; set; }
    }


}
