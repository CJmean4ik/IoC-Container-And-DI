using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI
{
    internal interface IContainerServices
    {
        void RegisterSingleton<TInterface>(TInterface implementator);
        void RegisterSingleton<TInterface, TImplementator>() where TImplementator : TInterface;

        void RegisterTransient<TInterface>(TInterface implementator);
        void RegisterTransient<TInterface, TImplementator>() where TImplementator : TInterface;

        void DeleteDependency<TInterface>();
        TInterface Resolve<TInterface>();      
    }
}
