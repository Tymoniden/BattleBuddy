namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public interface IListViewInteractionFacade
    {
        Task ExpandLeft();
        Task JustifyBoth();
        Task ExpandRight();
        Task ReloadLists();
        Task ScrollToEntry(ListViewIdentifier listViewIdentifier, int index);
        Task ScrollToPercentage(ListViewIdentifier listViewIdentifier, int percentage);
    }
}