using System;

namespace BattleBuddy.Services
{
    public class WindowModeService : IWindowModeService
    {
        private WindowState _state;

        public event EventHandler? StateChangeEvent;

        public void SetWindowState(WindowState state)
        {
            if (state != _state)
            {
                _state = state;
                StateChangeEvent?.Invoke(this, new StateChangedEventArgs { State = _state });
            }
        }

        public void ToogleFullscreen()
        {
            switch(_state)
            {
                case WindowState.Fullscreen:
                    SetWindowState(WindowState.Maximized);
                    break;
                default:
                    SetWindowState(WindowState.Fullscreen);
                    break;
            }
        }
    }
}
