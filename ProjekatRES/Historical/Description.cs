using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class Description
    {
        public int id { get; set; }
        public List<HistoricalProperty> props { get; set; }
        public int dataset { get; set; }

        public Description(int a, List<HistoricalProperty> b, int c)
        {
            id = a;
            props = b;
            dataset = c;
        }
    }
}
