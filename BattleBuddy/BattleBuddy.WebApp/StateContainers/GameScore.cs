namespace BattleBuddy.WebApp.StateContainers
{
    public class GameScore
    {
        public int PrimaryPlayerA { get; set; }
        public int PrimaryPlayerB { get; set; }
        public int SecondaryPlayerA { get; set; }
        public int SecondaryPlayerB { get; set; }

        public int TotalPlayerA => PrimaryPlayerA + SecondaryPlayerA;

        public int TotalPlayerB => PrimaryPlayerB + SecondaryPlayerB;

        public event EventHandler? OnChange;

        public void NotifyStateChanged()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
