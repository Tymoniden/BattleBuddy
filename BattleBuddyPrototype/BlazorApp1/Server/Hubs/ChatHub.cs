using BlazorApp1.Server.Services;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorApp1.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IEntryValueStore _entryValueStore;

        public ChatHub(IEntryValueStore entryValueStore)
        {
            _entryValueStore = entryValueStore ?? throw new ArgumentNullException(nameof(entryValueStore));
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task RegisterEntries(SideIdentifier side, List<string> entries)
        {
            _entryValueStore.AddEntries(side, entries);
            await Clients.All.SendAsync("ReloadEntries", side, entries);
        }

        public async Task ScrollTo(SideIdentifier side, string entry)
        {
            await Clients.All.SendAsync("ScrollToEntry", side, entry);
        }

        public async Task RequestScrollToIndex(SideIdentifier side, int index)
        {
            await Clients.All.SendAsync("ScrollToIndex", side, index);
        }

        public async Task RequestEntries()
        {
            await Clients.Caller.SendAsync("ReloadEntries", SideIdentifier.Left, _entryValueStore.GetEntries(SideIdentifier.Left));
            await Clients.Caller.SendAsync("ReloadEntries", SideIdentifier.Right, _entryValueStore.GetEntries(SideIdentifier.Right));
        }

        public async Task RequestFocus(string target)
        {
            await Clients.All.SendAsync("Focus", target);
        }
    }
}
