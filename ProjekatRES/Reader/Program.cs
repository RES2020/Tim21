using Biblioteka;
using Historical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Unesite kod:   ");
            string kod = Console.ReadLine();
            Value vrijednost = GetChanges.GetChangesForInterval((Code)Enum.Parse(typeof(Code), kod));
        }
    }
}
