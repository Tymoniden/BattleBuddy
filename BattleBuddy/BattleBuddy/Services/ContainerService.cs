using BattleBuddy.ViewModel;
using BattleBuddy.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public static class ContainerService
    {
        public static void SetupContainer(Container container)
        {
            container.RegisterSingleton<ViewModelFactory>();
            container.RegisterSingleton<IHotKeyService, HotKeyService>();
            container.RegisterSingleton<MainViewModel>();
            container.RegisterSingleton<HotKeysPanelViewModel>();
            container.RegisterSingleton<RosterDisplayViewModel>();
            container.RegisterSingleton<IHotKeyRegistrationService, HotKeyRegistrationService>();
        }
    }
}
