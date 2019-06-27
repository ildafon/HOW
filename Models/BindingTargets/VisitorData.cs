using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;
using System.ComponentModel.DataAnnotations;

namespace HoustonOnWire.Models.BindingTargets
{
    public class VisitorData
    {
        [Required]
        public string Name { get; set; }


        public string Email { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public long AvatarId { get; set; }

       

        public Visitor Visitor => new Visitor
        {
            Name = Name,
            Email = Email,
            Phone = Phone,
            Comment = Comment,
            Avatar = AvatarId == 0 ? null: new Avatar { AvatarId = AvatarId}
        };

    }
}
