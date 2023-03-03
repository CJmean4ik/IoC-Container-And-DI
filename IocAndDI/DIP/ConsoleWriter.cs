using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI.DIP
{
    internal class ConsoleWriter : IWriter
    {
        public Guid guid { get; } = Guid.NewGuid();

        public void Write()
        {
            Console.WriteLine(guid);
        }
    }
}
