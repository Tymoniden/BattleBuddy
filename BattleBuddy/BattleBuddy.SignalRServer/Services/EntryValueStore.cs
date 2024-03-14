using BattleBuddy.Shared;

namespace BattleBuddy.SignalRServer.Services
{
    public sealed class EntryValueStore : IEntryValueStore
    {
        readonly Dictionary<ColumnIdentifier, List<string>> _entries = new() { { ColumnIdentifier.Left, new List<string>() }, { ColumnIdentifier.Right, new List<string>() } };

        public void AddEntries(ColumnIdentifier sideIdentifier, List<string> entries)
        {
            if (!_entries.ContainsKey(sideIdentifier))
            {
                _entries[sideIdentifier] = new List<string>();
            }

            _entries[sideIdentifier].Clear();
            _entries[sideIdentifier].AddRange(entries);
        }

        public List<string> GetEntries(ColumnIdentifier sideIdentifier) => _entries.ContainsKey(sideIdentifier) ? _entries[sideIdentifier] : new List<string>();
    }
}
