namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public sealed class ListViewEntryProvider : IListViewEntryProvider
    {
        Dictionary<ListViewIdentifier, List<ListViewEntryViewModel>> _entries = new();

        public ListViewEntryProvider()
        {
            _entries.Add(ListViewIdentifier.Left, new List<ListViewEntryViewModel>
            {
                new ListViewEntryViewModel{ Name = "Left first" },
                new ListViewEntryViewModel{ Name = "Left second" },
                new ListViewEntryViewModel{ Name = "Left third" }
            });

            _entries.Add(ListViewIdentifier.Right, new List<ListViewEntryViewModel>
            {
                new ListViewEntryViewModel{ Name = "Right first" },
                new ListViewEntryViewModel{ Name = "Right second" },
                new ListViewEntryViewModel{ Name = "Right third" }
            });
        }

        public List<ListViewEntryViewModel> GetLists(ListViewIdentifier identifier)
        {
            if (_entries.ContainsKey(identifier))
            {
                return _entries[identifier];
            }

            return new List<ListViewEntryViewModel>();
        }
    }
}
