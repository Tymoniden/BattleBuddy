using BattleBuddy.Shared;

namespace BattleBuddy.SignalRServer.Services
{
    public sealed class EntryValueStore : IEntryValueStore
    {
        readonly Dictionary<SideIdentifier, List<string>> _entries = new() { { SideIdentifier.Left, new List<string>() }, { SideIdentifier.Right, new List<string>() } };

        public void AddEntries(SideIdentifier sideIdentifier, List<string> entries)
        {
            if (!_entries.ContainsKey(sideIdentifier))
            {
                _entries[sideIdentifier] = new List<string>();
            }

            _entries[sideIdentifier].Clear();
            _entries[sideIdentifier].AddRange(entries);
        }

        public List<string> GetEntries(SideIdentifier sideIdentifier) => _entries.ContainsKey(sideIdentifier) ? _entries[sideIdentifier] : new List<string>();
    }
}
