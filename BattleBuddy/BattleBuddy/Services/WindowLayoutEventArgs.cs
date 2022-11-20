using System;

namespace BattleBuddy.Services
{
    public sealed class WindowLayoutEventArgs : EventArgs
    {
        public WindowLayoutType NewLayout { get; init; }
    }
}
