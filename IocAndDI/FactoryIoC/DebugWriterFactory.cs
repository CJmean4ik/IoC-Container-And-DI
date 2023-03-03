using IocAndDI.DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI.FactoryIoC
{
    internal class DebugWriterFactory : WriterFactory
    {
        public override IWriter GetWriter()
        {
            return new DebugWriter();
        }
    }
}
