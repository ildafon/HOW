using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class Customer
    {
        public long CustomerId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }


        public long? AvatarId { get; set; }
        public Avatar Avatar { get; set; }


        public IEnumerable<ChannelCustomer> ChannelCustomers { get; set; }

        public ICollection<Chat> Chats { get; set; }

        
    }
}
