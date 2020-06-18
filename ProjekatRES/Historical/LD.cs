using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class LD
    {
        public List<Description> list { get; set; }

        public LD(List<Description> a)
        {
            list = a;
        }
    }
}
