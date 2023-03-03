using IocAndDI.DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI.FactoryIoC
{
    internal class ConsoleWriterFactory : WriterFactory
    {
        public override IWriter GetWriter()
        {
            return new ConsoleWriter();
        }
    }
}
