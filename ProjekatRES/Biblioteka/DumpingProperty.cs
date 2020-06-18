
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class DumpingProperty
    {
        public Code kod { get; set; }
        public Value DumpingValue { get; set; }

        public DumpingProperty(Code k, Value v)
        {
            kod = k;
            DumpingValue = v;
        }
    }
}
