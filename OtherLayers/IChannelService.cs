using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Lib;
using HoustonOnWire.Models;

namespace HoustonOnWire.OtherLayers
{
    public interface IChannelService
    {
        PagedList<Channel> GetChannelsPaged(FilterParams filterParams);

        Channel GetChannel(long id);
    }
}
