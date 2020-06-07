using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class DeltaCD
    {
        public int transactionID { get; set; }
        public CollectionDescription Add { get; set; }
        public CollectionDescription Update { get; set; }
        public CollectionDescription Delete { get; set; }

        public DeltaCD(int a, CollectionDescription b, CollectionDescription c, CollectionDescription d)
        {
            transactionID = a;
            Add = b;
            Update = c;
            Delete = d;
        }
    }
}
