namespace BattleBuddy.WebApp.StateContainers
{
    public class SessionConfiguration
    {
        private Participants _participantRole;
        
        public Participants ParticipantRole
        {
            get => _participantRole;
            set
            {
                _participantRole = value;
                OnChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? OnChange;
    }
}
