namespace BattleBuddy.BlazorWebApp.Client.Services
{
    public class ListViewEntryViewModel
    {
        public int Index { get; set; }
        public bool Selected { get; set; }

        public string Name { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            if(obj is ListViewEntryViewModel model && model?.Index == Index)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
