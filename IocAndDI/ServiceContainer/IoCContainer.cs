using System.Reflection;

namespace IocAndDI.ServiceContainer
{
    internal class IoCContainer : IContainerServices
    {
        private readonly Dictionary<Type, object> _container = new Dictionary<Type, object>();
        private readonly Dictionary<Type, ServiceLifeTime> _serviceslife = new Dictionary<Type, ServiceLifeTime>();

        public void RegisterSingleton<TInterface>(TInterface implementator)
        {
            _container.Add(typeof(TInterface), implementator!);
            _serviceslife.Add(typeof(TInterface), ServiceLifeTime.Singleton);
        }
        public void RegisterSingleton<TInterface, TImplementator>() where TImplementator : TInterface
        {
            RegisterSingleton<TInterface>(Activator.CreateInstance<TImplementator>());
        }

        public void RegisterTransient<TInterface>(TInterface implementator)
        {
            _container.Add(typeof(TInterface), implementator!);
            _serviceslife.Add(typeof(TInterface), ServiceLifeTime.Transient);
        }
        public void RegisterTransient<TInterface, TImplementator>() where TImplementator : TInterface
        {
            RegisterTransient<TInterface>(Activator.CreateInstance<TImplementator>());
        }

        public void DeleteDependency<TInterface>()
        {
            if (_container.ContainsKey(typeof(TInterface)))
                if (_serviceslife.ContainsKey(typeof(TInterface)))
                {
                    _container.Remove(typeof(TInterface));
                    _serviceslife.Remove(typeof(TInterface));
                }
                else
                    Console.WriteLine($"Зависимости {typeof(TInterface).Name} нет в колекции");
        }
        public TInterface Resolve<TInterface>()
        {
            try
            {
                var service = _container.FirstOrDefault(f => f.Key == typeof(TInterface)).Value;
                var servicelife = _serviceslife?.FirstOrDefault(f => f.Key == typeof(TInterface)).Value;
                if (servicelife != null && servicelife == ServiceLifeTime.Singleton)
                {
                    return GetSingletonService<TInterface>(service);
                }

                if (servicelife != null && servicelife == ServiceLifeTime.Transient)
                {
                    return GetTransientService<TInterface>(service);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return default!;
        }

        private TInterface GetSingletonService<TInterface>(object typeService)
        {
            if (typeService != null)
                return (TInterface)typeService;

            return default!;
        }
        private TInterface GetTransientService<TInterface>(object typeService)
        {
            if (typeService != null)
            {
                var keyType = _container
                    .Keys
                    .FirstOrDefault(f => f.Name == typeof(TInterface).Name);
                if (keyType != null)
                    return (TInterface)Creator(keyType);
            }
            return default!;
        }
        private object Creator(Type type)
        {
            var concreteType = _container[type].GetType();
            return concreteType
                .GetConstructors()[0]
                .Invoke(null);
        }
    }
}
