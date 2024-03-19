using BattleBuddy.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleBuddy.Services
{
    public class HotKeyService : IHotKeyService
    {
        Dictionary<HotKeyViewModel, Func<Task>> _hotKeys { get; set; } = new();

        public void RegisterHotkey(HotKeyViewModel hotkey, Func<Task> action)
        {
            _hotKeys.Add(hotkey, action);
        }

        public List<HotKeyViewModel> GetHotKeys()
        {
            return _hotKeys.Keys.OrderBy(k => k.Key).ToList();
        }

        public async Task ExecuteHotkey(Key key, ModifierKeys modifier)
        {
            var keyViewModel = _hotKeys.FirstOrDefault(entry =>
                entry.Key.Key == key &&
                entry.Key.Control == ((modifier & ModifierKeys.Control) == ModifierKeys.Control) &&
                entry.Key.Shift == ((modifier & ModifierKeys.Shift) == ModifierKeys.Shift) &&
                entry.Key.Alt == ((modifier & ModifierKeys.Alt) == ModifierKeys.Alt)
                );

            if (keyViewModel.Value != null)
            {
                await keyViewModel.Value.Invoke();
            }
        }
    }
}
