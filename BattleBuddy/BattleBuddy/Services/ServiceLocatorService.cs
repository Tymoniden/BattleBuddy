﻿using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Services
{
    public class ServiceLocatorService
    {
        static Container? _container;

        public static void RegisterContainer(Container container)
        {
            _container = container;
        }

        public static IServiceInstance GetInstance<IServiceInstance>() where IServiceInstance : class
        {
            if(_container == null)
            {
                throw new InvalidOperationException($"{nameof(_container)} was not setup at startup.");
            }

            return _container.GetInstance<IServiceInstance>();
        }
    }
}
