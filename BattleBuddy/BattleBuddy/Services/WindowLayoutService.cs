using System;
using BattleBuddy.Services.SignalR;

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

            hotKeyRegistrationService.RegisterHotKey(System.Windows.Input.Key.F6,
                System.Windows.Input.ModifierKeys.None, "Focus left side",
                async () =>
                {
                    ExtendLeftColumn();
                    await _signalRService.SendMessage("ExtendLeftColumn");
                });
            hotKeyRegistrationService.RegisterHotKey(System.Windows.Input.Key.F7, System.Windows.Input.ModifierKeys.None, "Justigy sides",
                async () =>
                {
                    JustifyColumns();
                    await _signalRService.SendMessage("JustifyColumns");
                });
            hotKeyRegistrationService.RegisterHotKey(System.Windows.Input.Key.F8, System.Windows.Input.ModifierKeys.None, "Focus right side",
                async () =>
                {
                    ExtendRightColumn();
                    await _signalRService.SendMessage("ExtendRightColumn");
                });
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
