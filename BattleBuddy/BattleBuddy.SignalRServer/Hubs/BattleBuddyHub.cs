using BattleBuddy.BlazorWebApp.Shared.Enums;
using BattleBuddy.Shared;
using BattleBuddy.SignalRServer.Services;
using Microsoft.AspNetCore.SignalR;

namespace BattleBuddy.SignalRServer.Hubs
{
    public class BattleBuddyHub : Hub
    {
        private readonly IEntryValueStore _entryValueStore;

        public BattleBuddyHub(IEntryValueStore entryValueStore)
        {
            _entryValueStore = entryValueStore ?? throw new ArgumentNullException(nameof(entryValueStore));
        }

        public async Task RegisterEntries(ColumnIdentifier side, List<string> entries)
        {
            _entryValueStore.AddEntries(side, entries);
            await Clients.All.SendAsync(nameof(SignalRMessages.ReloadEntries), side, entries);
        }

        public async Task ScrollTo(ColumnIdentifier side, string entry)
        {
            await Clients.All.SendAsync(nameof(SignalRMessages.ScrollToEntry), side, entry);
        }

        public async Task RequestScrollToIndex(ColumnIdentifier side, int index)
        {
            await Clients.All.SendAsync(nameof(SignalRMessages.ScrollToIndex), side, index);
        }

        public async Task RequestReload()
        {
            await Clients.All.SendAsync(nameof(SignalRMessages.SendEntries));
        }

        public async Task RequestEntries()
        {
            await Clients.Caller.SendAsync(nameof(SignalRMessages.ReloadEntries), ColumnIdentifier.Left, _entryValueStore.GetEntries(ColumnIdentifier.Left));
            await Clients.Caller.SendAsync(nameof(SignalRMessages.ReloadEntries), ColumnIdentifier.Right, _entryValueStore.GetEntries(ColumnIdentifier.Right));
        }

        public async Task RequestFocus(string target)
        {
            await Clients.All.SendAsync(nameof(SignalRMessages.Focus), target);
        }
    }
}
