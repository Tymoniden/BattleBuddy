using System;

namespace BattleBuddy.Services
{
    public sealed class WindowLayoutService : IWindowLayoutService
    {
        public event EventHandler<WindowLayoutEventArgs>? WindowLayoutChanged;

        public WindowLayoutService(IHotKeyRegistrationService hotKeyRegistrationService)
        {
            if (hotKeyRegistrationService is null)
            {
                throw new ArgumentNullException(nameof(hotKeyRegistrationService));
            }

            hotKeyRegistrationService.RegisterHotKey(System.Windows.Input.Key.F6, System.Windows.Input.ModifierKeys.None, "Focus left side", ExtendLeftColumn);
            hotKeyRegistrationService.RegisterHotKey(System.Windows.Input.Key.F7, System.Windows.Input.ModifierKeys.None, "Justigy sides", JustifyColumns);
            hotKeyRegistrationService.RegisterHotKey(System.Windows.Input.Key.F8, System.Windows.Input.ModifierKeys.None, "Focus right side", ExtendRightColumn);
        }

        public void ExtendLeftColumn() 
        {
            WindowLayoutChanged?.Invoke(this, new WindowLayoutEventArgs { NewLayout = WindowLayoutType.ExtendLeft });
        }

        public void ExtendRightColumn() 
        {
            WindowLayoutChanged?.Invoke(this, new WindowLayoutEventArgs { NewLayout = WindowLayoutType.ExtendRight });
        }

        public void JustifyColumns() 
        {
            WindowLayoutChanged?.Invoke(this, new WindowLayoutEventArgs { NewLayout = WindowLayoutType.Justify });
        }
    }
}
