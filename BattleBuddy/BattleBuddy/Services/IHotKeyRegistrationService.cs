using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleBuddy.Services
{
    public interface IHotKeyRegistrationService
    {
        void RegisterHotKey(Key key, ModifierKeys modifierKeys, string description, Action action);
        void RegisterHotKey(Key key, ModifierKeys modifierKeys, string description, Func<Task> action);
    }
}