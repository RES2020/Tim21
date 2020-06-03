using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Value
    {
        public DateTime timestamp { get; set; }
        public int id { get; set; }
        public double potrosnja { get; set; }

        public Value(DateTime date,int sifra,double cost)
        {
            timestamp = date;
            id = sifra;
            potrosnja = cost;
        }
    }
}
