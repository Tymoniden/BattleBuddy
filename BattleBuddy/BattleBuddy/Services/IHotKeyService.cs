using BattleBuddy.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleBuddy.Services
{
    public interface IHotKeyService
    {
        Task ExecuteHotkey(Key key, ModifierKeys modifier, KeyboardEventArgs e);
        List<HotKeyViewModel> GetHotKeys();
        void RegisterHotkey(HotKeyViewModel hotkey, Func<Task> action);
    }
}