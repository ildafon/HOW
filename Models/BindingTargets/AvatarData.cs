using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Models;
using System.ComponentModel.DataAnnotations;

namespace HoustonOnWire.Models.BindingTargets
{
    public class AvatarData
    {
        [Required]
        public string Url { get; set; }
        public Avatar Avatar => new Avatar
        {
            Url = Url
        };
    }
}
