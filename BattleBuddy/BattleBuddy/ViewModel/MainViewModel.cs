using BattleBuddy.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BattleBuddy.ViewModel
{
    public sealed class MainViewModel : Base.ViewModel
    {
        public MainViewModel()
        {
            HotKeys.Add(new HotKeyViewModel{ Key = Key.F1 , Description = "Show Hotkeys" });
            HotKeys.Add(new HotKeyViewModel{ Key = Key.F2 , Description = "Hotkey for F2" , Control = true});
            HotKeys.Add(new HotKeyViewModel{ Key = Key.F3 , Description = "Hotkey for F3" , Shift = true});
            HotKeys.Add(new HotKeyViewModel{ Key = Key.F4 , Description = "Hotkey for F4" , Control = true, Shift = true, Alt = true});

            //ShowHotkeysCommand = new CommandFactory().Create();
        }

        public ObservableCollection<HotKeyViewModel> HotKeys { get; set; } = new ObservableCollection<HotKeyViewModel>();

        public Command ShowHotkeysCommand { get; }

        public bool IsHotKeyPanelVisible
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
    }
}
