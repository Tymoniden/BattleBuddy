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
        }
    }
}
