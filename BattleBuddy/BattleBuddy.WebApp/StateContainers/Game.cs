using BattleBuddy.WebApp.Services;

namespace BattleBuddy.WebApp.StateContainers
{
    public class Game
    {
        public event EventHandler? OnChange;

        public Game(GameScore gameScore)
        {
            GameScore = gameScore ?? throw new ArgumentNullException(nameof(gameScore));
            _columnLayout = ColumnLayout.Justify;
        }

        public GameScore GameScore { get; set; }

        public List<ArmyListEntryDto> ArmyListEntries { get; set; } = new();

        private ColumnLayout _columnLayout;

        public ColumnLayout ColumnLayout
        {
            get => _columnLayout;
            set
            {
                _columnLayout = value;
                OnChange?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
