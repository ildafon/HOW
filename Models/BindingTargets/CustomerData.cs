using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;
using System.ComponentModel.DataAnnotations;

namespace HoustonOnWire.Models.BindingTargets
{
    public class CustomerData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public long Avatar { get; set; }

        public ChannelCustomer[] ChannelCustomers { get; set; }

        public Customer Customer => new Customer
        {
            Name = Name,
            Email = Email,
            Avatar = Avatar == 0 ? null : new Avatar { AvatarId = Avatar},
            ChannelCustomers = ChannelCustomers
        };

    }
}
