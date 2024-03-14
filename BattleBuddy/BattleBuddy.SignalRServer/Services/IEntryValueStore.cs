using BattleBuddy.Shared;

namespace BattleBuddy.SignalRServer.Services;

public interface IEntryValueStore
{
    void AddEntries(ColumnIdentifier sideIdentifier, List<string> entries);
    List<string> GetEntries(ColumnIdentifier sideIdentifier);
}