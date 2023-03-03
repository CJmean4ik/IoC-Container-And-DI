using IocAndDI.DIP;
using IocAndDI.FactoryIoC;
using IocAndDI.ServiceContainer;

namespace IocAndDI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region IoC with IoC container
            
            IContainerServices container = new IoCContainer();
            container.RegisterSingleton<IWriter>(new ConsoleWriter());

            Logger logger1 = new Logger(container.Resolve<IWriter>());
            Logger logger2 = new Logger(container.Resolve<IWriter>());
            logger1.Write();
            logger2.Write();
            
            #endregion

            #region IoC with а Factory
            /*
            WriterFactory factory = new ConsoleWriterFactory();
            Logger logger = new Logger(factory.GetWriter());
            logger.Write();
            */
            #endregion

            #region IoC with a Dependency Injection Through constructor
            /*
            Logger logger = new Logger(new DebugWriter());
            logger.Write();
            */
            #endregion

        }
    }
}