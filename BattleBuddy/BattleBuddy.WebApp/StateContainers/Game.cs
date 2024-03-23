using BattleBuddy.Shared;
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

        public int LeftZoomFactor { get; private set; } = 100;

        public int RightZoomFactor { get; private set; } = 100;

        public ArmyListEntryDto SelectedLeftArmyListEntry { get; private set; }

        public ArmyListEntryDto SelectedRightArmyListEntry { get; private set; }

        public List<ArmyListEntryDto> ArmyListEntries { get; set; } = [];

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

        public void ChangeZoomFactor(SideIdentifier sideIdentifier, int zoomFactor)
        {
            if(sideIdentifier == SideIdentifier.Left)
            {
                LeftZoomFactor = zoomFactor;
            }

            if(sideIdentifier == SideIdentifier.Right)
            {
                RightZoomFactor = zoomFactor;
            }

            OnChange?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeSelectedArmyListEntry(SideIdentifier sideIdentifier, ArmyListEntryDto selectedArmyListEntry)
        {
            if(sideIdentifier == SideIdentifier.Left)
            {
                SelectedLeftArmyListEntry = selectedArmyListEntry;
            }

            if(sideIdentifier == SideIdentifier.Right)
            {
                SelectedRightArmyListEntry = selectedArmyListEntry;
            }

            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
