using BattleBuddy.WebApp.StateContainers;

namespace BattleBuddy.WebApp.Services
{
    public class GameDto
    {
        public ArmyListDto PlayerAArmyList { get; set; } = new();

        public ArmyListDto PlayerBArmyList { get; set; } = new();

        public GameScore GameScore { get; set; } = new();
    }
}
