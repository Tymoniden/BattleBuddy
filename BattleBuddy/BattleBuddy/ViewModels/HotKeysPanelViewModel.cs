using BattleBuddy.Services;
using BattleBuddy.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BattleBuddy.ViewModels
{
    public class HotKeysPanelViewModel : Base.ViewModel
    {
        private readonly IHotKeyRegistrationService _hotKeyRegistrationService;
        private readonly IHotKeyService _hotKeyService;
        private readonly IWindowModeService _windowModeService;

        public HotKeysPanelViewModel(IHotKeyRegistrationService hotKeyRegistrationService, IHotKeyService hotKeyService, IWindowModeService windowModeService)
        {
            _hotKeyRegistrationService = hotKeyRegistrationService ?? throw new System.ArgumentNullException(nameof(hotKeyRegistrationService));
            _hotKeyService = hotKeyService ?? throw new System.ArgumentNullException(nameof(hotKeyService));
            _windowModeService = windowModeService ?? throw new System.ArgumentNullException(nameof(windowModeService));
        }

        public ObservableCollection<HotKeyViewModel> HotKeys { get; set; } = new ObservableCollection<HotKeyViewModel>();

        public void Setup()
        {
            _hotKeyRegistrationService.RegisterHotKey(Key.F1, ModifierKeys.None, "Toggle Hotkeys", () =>
            {
                if (!IsHotKeyPanelVisible)
                {
                    Application.Current.Dispatcher.Invoke(UpdateHotkeys);
                }

                IsHotKeyPanelVisible = !IsHotKeyPanelVisible;
            });

            _hotKeyRegistrationService.RegisterHotKey(Key.F11, ModifierKeys.None, "Toggle Fullscreen", () => {
                _windowModeService.ToogleFullscreen();
            });
        }

        public bool IsHotKeyPanelVisible
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public void UpdateHotkeys()
        {
            HotKeys.Clear();
            HotKeys = new ObservableCollection<HotKeyViewModel>(_hotKeyService.GetHotKeys());
            NotifyPropertyChanged(nameof(HotKeys));
        }
    }
}
