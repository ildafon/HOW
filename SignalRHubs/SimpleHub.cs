using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HoustonOnWire.SignalRHubs
{
    public class SimpleHub : Hub
    {
        public Task Send(string data)
        {
            var d = $"{Clients.All}   {Clients.Client(Context.ConnectionId)}: {data}";
            return Clients.All.SendAsync("SendMessage", d);
        }
    }
}
