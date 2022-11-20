using System;

namespace BattleBuddy.Services
{
    public interface IWindowLayoutService
    {
        event EventHandler<WindowLayoutEventArgs>? WindowLayoutChanged;

        void ExtendLeftColumn();
        void ExtendRightColumn();
        void JustifyColumns();
    }
}