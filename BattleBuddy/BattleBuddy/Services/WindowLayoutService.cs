using BattleBuddy.BlazorWebApp.Shared.Enums;
using System;

namespace BattleBuddy.Services
{
    public sealed class WindowLayoutService : IWindowLayoutService
    {
        private readonly ISignalRService _signalRService;

        public event EventHandler<WindowLayoutEventArgs>? WindowLayoutChanged;

        public WindowLayoutService(IHotKeyRegistrationService hotKeyRegistrationService, ISignalRService signalRService)
        {
            if (hotKeyRegistrationService is null)
            {
                throw new ArgumentNullException(nameof(hotKeyRegistrationService));
            }

            _signalRService = signalRService ?? throw new ArgumentNullException(nameof(signalRService));

            _signalRService.RegisterCallback<LayoutValue>(nameof(SignalRMessages.RequestFocus), (layoutValue) => Focus(layoutValue));

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

        void Focus(LayoutValue value)
        {
            switch(value)
            {
                case LayoutValue.Left:
                    ExtendLeftColumn();
                    break;
                case LayoutValue.Right:
                    ExtendRightColumn();
                    break;
                case LayoutValue.Justify:
                    JustifyColumns();
                    break;
            }
        }
    }
}
