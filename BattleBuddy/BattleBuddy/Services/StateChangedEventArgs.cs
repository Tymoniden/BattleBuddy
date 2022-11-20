using System;

namespace BattleBuddy.Services
{
    public sealed class StateChangedEventArgs : EventArgs
    {
        public WindowState State { get; init; }
    }
}
