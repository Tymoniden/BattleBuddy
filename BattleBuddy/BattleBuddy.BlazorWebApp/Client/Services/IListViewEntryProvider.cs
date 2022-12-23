namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public interface IListViewEntryProvider
    {
        List<ListViewEntryViewModel> GetLists(ListViewIdentifier identifier);
    }
}