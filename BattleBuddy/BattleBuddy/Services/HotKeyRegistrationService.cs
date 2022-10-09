using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleBuddy.Services
{
    public class HotKeyRegistrationService : IHotKeyRegistrationService
    {
        private readonly IHotKeyService _hotKeyService;
        private readonly ViewModelFactory _viewModelFactory;

        public HotKeyRegistrationService(IHotKeyService hotKeyService, ViewModelFactory viewModelFactory)
        {
            _hotKeyService = hotKeyService ?? throw new ArgumentNullException(nameof(hotKeyService));
            _viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
        }

        public void RegisterHotKey(Key key, ModifierKeys modifierKeys, string description, Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _hotKeyService.RegisterHotkey(
                _viewModelFactory.CreateHotKeyViewModel(key, modifierKeys, description),
                async () => { await Task.Run(action); });
        }

        public void RegisterHotKey(Key key, ModifierKeys modifierKeys, string description, Func<Task> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _hotKeyService.RegisterHotkey(
                _viewModelFactory.CreateHotKeyViewModel(key, modifierKeys, description),
                async () => { await action.Invoke(); });
        }
    }
}
