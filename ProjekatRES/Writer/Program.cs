using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Biblioteka;
using DumpingBuffer;
using Historical;

namespace Writer
{
    class Program
    {
        //uradjeno
        static void Main(string[] args)
        {
            Sending sendi = new Sending();
            Thread tredi = new Thread(new ThreadStart(sendi.Salji));
            tredi.Start();

                

            while (true)
            {
                Console.WriteLine("Izaberite opciju: " + Environment.NewLine + "1. Manual write to history" + Environment.NewLine + "2. Get changes for interval" + Environment.NewLine);
                string opcija = Console.ReadLine();
                if (opcija.Equals("1"))
                {
                    Console.WriteLine("Izabrali ste prvu opciju - Manual write to history");
                    Console.WriteLine("Unesite kod: ");
                    string kod = Console.ReadLine();
                    Console.WriteLine("Unesite id geografskoh podrucja: ");
                    string areaId = Console.ReadLine();
                    Console.WriteLine("Unesite potrosnju: ");
                    string potrosnja = Console.ReadLine();
                    string datum = DateTime.Now.ToShortDateString();
                    Manual mani = new Manual(kod, datum, areaId, potrosnja);
                    mani.ManualWriteToHistory();

                }
                else if (opcija.Equals("2"))
                {
                    Console.WriteLine("Izabrali ste drugu opciju - Get changes for interval");
                    Console.WriteLine("Unesite kod: ");
                    string kod = Console.ReadLine();

                    Get geti = new Get(kod);
                    Console.WriteLine(geti.GetValue());

                }
                else
                {
                    Console.WriteLine("Greska");
                    return;
                }

            }






        }


    }
}