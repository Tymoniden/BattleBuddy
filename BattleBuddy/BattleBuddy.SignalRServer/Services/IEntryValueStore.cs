using BattleBuddy.Shared;

namespace BattleBuddy.SignalRServer.Services;

public interface IEntryValueStore
{
    void AddEntries(SideIdentifier sideIdentifier, List<string> entries);
    List<string> GetEntries(SideIdentifier sideIdentifier);
}