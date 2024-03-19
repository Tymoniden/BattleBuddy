using BattleBuddy.WebApp.StateContainers;

namespace BattleBuddy.WebApp.Services
{
    public class ScoreService
    {
        private readonly GameScore _gameScore;

        public ScoreService(GameScore gameScore)
        {
            _gameScore = gameScore ?? throw new ArgumentNullException(nameof(gameScore));
        }

        public void ModifyScore(ScoreModifier modifier, int amount = 1)
        {
            switch (modifier)
            {
                case ScoreModifier.IncreasePrimaryA:
                    _gameScore.PrimaryPlayerA += amount;
                    break;
                case ScoreModifier.IncreasePrimaryB:
                    _gameScore.PrimaryPlayerB += amount;
                    break;
                case ScoreModifier.DecreasePrimaryA:
                    _gameScore.PrimaryPlayerA -= amount;
                    break;
                case ScoreModifier.DecreasePrimaryB:
                    _gameScore.PrimaryPlayerB -= amount;
                    break;
                case ScoreModifier.IncreaseSecondaryA:
                    _gameScore.SecondaryPlayerA += amount;
                    break;
                case ScoreModifier.IncreaseSecondaryB:
                    _gameScore.SecondaryPlayerB += amount;
                    break;
                case ScoreModifier.DecreaseSecondaryA:
                    _gameScore.SecondaryPlayerA -= amount;
                    break;
                case ScoreModifier.DecreaseSecondaryB:
                    _gameScore.SecondaryPlayerB -= amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null);
            }

            _gameScore.NotifyStateChanged();
        }
    }

    public enum ScoreModifier
    {
        IncreasePrimaryA,
        IncreasePrimaryB,
        DecreasePrimaryA,
        DecreasePrimaryB,
        IncreaseSecondaryA,
        IncreaseSecondaryB,
        DecreaseSecondaryA,
        DecreaseSecondaryB
    }
}
