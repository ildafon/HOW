using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;
using System.ComponentModel.DataAnnotations;

namespace HoustonOnWire.Models.BindingTargets
{
    public class ChannelData
    {
        [Required]
        public string Name { get; set; }

        public ChannelCustomer[] ChannelCustomers { get; set; }

        public Channel Channel => new Channel
        {
            Name = Name,
            ChannelCustomers = ChannelCustomers
        };

    }
}
