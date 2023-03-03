using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI.DIP
{
    internal class DebugWriter : IWriter
    {
        public Guid guid { get; } = Guid.NewGuid();
        public void Write()
        {
            Debug.WriteLine(guid);
        }
    }
}
