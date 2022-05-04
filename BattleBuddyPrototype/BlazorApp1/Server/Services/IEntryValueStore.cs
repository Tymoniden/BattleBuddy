using BlazorApp1.Shared;

namespace BlazorApp1.Server.Services;

public interface IEntryValueStore
{
    void AddEntries(SideIdentifier sideIdentifier, List<string> entries);
    List<string> GetEntries(SideIdentifier sideIdentifier);
}