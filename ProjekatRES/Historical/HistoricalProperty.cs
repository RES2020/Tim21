using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class HistoricalProperty
    {
        public Code kod { get; set; }
        public Value HistoricalValue { get; set; }

        public HistoricalProperty(Code a, Value b)
        {
            kod = a;
            HistoricalValue = b;
        }
    }
}
