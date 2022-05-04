﻿using BlazorApp1.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorApp1.Server.Hubs
{
    public class ChatHub : Hub
    {
        Dictionary<SideIdentifier, List<string>> _entries = new Dictionary<SideIdentifier, List<string>> { { SideIdentifier.Left, new() }, { SideIdentifier.Right, new() } };

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task RegisterEntries(SideIdentifier side, List<string> entries)
        {
            _entries[side] = entries;
            await Clients.All.SendAsync("ReloadEntries", side, entries);
        }

        public async Task ScrollTo(SideIdentifier side, string entry)
        {
            await Clients.All.SendAsync("ScrollToEntry", side, entry);
        }

        public async Task RequestEntries()
        {
            await Clients.Caller.SendAsync("ReloadEntries", SideIdentifier.Left, _entries[SideIdentifier.Left]);
            await Clients.Caller.SendAsync("ReloadEntries", SideIdentifier.Right, _entries[SideIdentifier.Right]);
        }

        public async Task RequestFocus(string target)
        {
            await Clients.All.SendAsync("Focus", target);
        }
    }
}