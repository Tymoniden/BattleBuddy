using System;

namespace BattleBuddy.Services.Container
{
    public class ServiceLocatorService
    {
        static SimpleInjector.Container? _container;

        public static void RegisterContainer(SimpleInjector.Container container)
        {
            _container = container;
        }

        public static TServiceInstance GetInstance<TServiceInstance>() where TServiceInstance : class
        {
            if (_container == null)
            {
                throw new InvalidOperationException($"{nameof(_container)} was not setup at startup.");
            }

            return _container.GetInstance<TServiceInstance>();
        }
    }
}
