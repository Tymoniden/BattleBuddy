using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleBuddy.Services
{
    public class RosterDisplayViewModel : Base.ViewModel
    {
        private readonly IHotKeyRegistrationService _hotKeyRegistrationService;

        public RosterDisplayViewModel(IHotKeyRegistrationService hotKeyRegistrationService)
        {
            _hotKeyRegistrationService = hotKeyRegistrationService ?? throw new ArgumentNullException(nameof(hotKeyRegistrationService));

            _hotKeyRegistrationService.RegisterHotKey(Key.F5, ModifierKeys.None, "Expand left Roster", ExpandLeftRoster);
            _hotKeyRegistrationService.RegisterHotKey(Key.F6, ModifierKeys.None, "justify Rosters", ExpandLeftRoster);
            _hotKeyRegistrationService.RegisterHotKey(Key.F7, ModifierKeys.None, "Expand right Roster", ExpandLeftRoster);
        }

        public void ExpandLeftRoster()
        {

        }
    }
}
