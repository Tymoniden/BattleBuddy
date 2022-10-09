using BattleBuddy.ViewModel;
using System.Windows.Input;

namespace BattleBuddy.Services
{
    public class ViewModelFactory
    {
        public HotKeyViewModel CreateHotKeyViewModel(Key key, bool ctrl, bool shift, bool alt, string description)
        {
            return new HotKeyViewModel
            {
                Key = key,
                Control = ctrl,
                Shift = shift,
                Alt = alt,
                Description = description
            };
        }

        public HotKeyViewModel CreateHotKeyViewModel(Key key, ModifierKeys modifierKeys, string description)
        {
            return new HotKeyViewModel
            {
                Key = key,
                Control = (modifierKeys & ModifierKeys.Control) == ModifierKeys.Control,
                Shift = (modifierKeys & ModifierKeys.Shift) == ModifierKeys.Shift,
                Alt = (modifierKeys & ModifierKeys.Alt) == ModifierKeys.Alt,
                Description = description
            };
        }
    }
}
