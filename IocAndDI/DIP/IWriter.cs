using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocAndDI.DIP
{
    internal interface IWriter
    {
        public Guid guid { get;}
        void Write();
    }
}
