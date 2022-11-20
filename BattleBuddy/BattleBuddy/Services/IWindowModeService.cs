using System;

namespace BattleBuddy.Services
{
    public interface IWindowModeService
    {
        event EventHandler? StateChangeEvent;

        void SetWindowState(WindowState state);
        void ToogleFullscreen();
    }
}