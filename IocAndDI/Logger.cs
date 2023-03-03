using IocAndDI.DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI
{
    internal class Logger
    {
        private IWriter writer;

        public Logger(IWriter writer)
        {
            this.writer = writer;
        }
        public void Write()
        {
            writer.Write();
        }
    }
}
