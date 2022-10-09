using BattleBuddy.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BattleBuddy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var container = new Container();
            ContainerService.SetupContainer(container);
            ServiceLocatorService.RegisterContainer(container);
        }
    }
}
