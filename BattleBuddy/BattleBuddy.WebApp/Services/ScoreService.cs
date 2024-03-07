namespace BattleBuddy.WebApp.Services
{
    public class ScoreService
    {
        private readonly Score _gameScore;

        public ScoreService(Score gameScore)
        {
            _gameScore = gameScore ?? throw new ArgumentNullException(nameof(gameScore));
        }

        public void ModifyScore(ScoreModifier modifier, int amount = 1)
        {
            switch (modifier)
            {
                case ScoreModifier.IncreasePrimaryA:
                    //_gameScore.PrimaryPlayerA += amount;
                    _gameScore.Update();
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

    public class Score
    {
        public int PrimaryPlayerA { get; set; }
        public int PrimaryPlayerB { get; set;  }
        public int SecondaryPlayerA { get; set; }
        public int SecondaryPlayerB { get; set; }

        public int TotalPlayerA => PrimaryPlayerA + SecondaryPlayerA;

        public int TotalPlayerB => PrimaryPlayerB + SecondaryPlayerB;

        public event EventHandler? OnChange;

        public void Update()
        {
            PrimaryPlayerA += 1;
            NotifyStateChanged();
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
