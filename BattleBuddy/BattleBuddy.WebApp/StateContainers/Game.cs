using BattleBuddy.WebApp.Services;

namespace BattleBuddy.WebApp.StateContainers
{
    public class Game
    {
        public Game(GameScore gameScore)
        {
            GameScore = gameScore ?? throw new ArgumentNullException(nameof(gameScore));
        }

        public GameScore GameScore { get; set; }

        public List<ArmyListEntryDto> ArmyListEntries { get; set; } = new();
    }
}
