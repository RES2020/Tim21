using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class CollectionDescription
    {
        public int id { get; set; }
        public int dataset { get; set; }
        public List<DumpingProperty> DumpingPropertyCollection { get; set; }

        public CollectionDescription(int a, int b, List<DumpingProperty> c)
        {
            id = a;
            dataset = b;
            DumpingPropertyCollection = c;
        }
    }
}
