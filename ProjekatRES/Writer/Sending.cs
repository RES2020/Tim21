using Biblioteka;
using DumpingBuffer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Writer
{
    public class Sending
    {
        public void Salji()
        {
            Console.WriteLine("Saljem podatke DumpingBafferu...");
            Bafer baf = new Bafer();

            Random rand = new Random();
            while (true)
            {
                int code = rand.Next(10);
                int podrucje = rand.Next(1000, 1000000);
                double vrednost = rand.Next(1000);

                DumpingProperty y = new DumpingProperty((Code)code, new Value(DateTime.Now, podrucje, vrednost));

                string poruka = "Writer poslao podatke: Code: " + y.kod.ToString() + " Value: " + y.DumpingValue.timestamp + " " + y.DumpingValue.id + " " + y.DumpingValue.potrosnja + Environment.NewLine;
                string pr1 = Directory.GetCurrentDirectory();
                string projectDirectory3 = Directory.GetParent(pr1).Parent.Parent.FullName;
                string p = Path.Combine(projectDirectory3 + @"\Biblioteka", "Loger.txt");
                FileStream stream1 = new FileStream(p, FileMode.Append);
                StreamWriter sw = new StreamWriter(stream1);
                sw.WriteLine(poruka);
                sw.Close();
                stream1.Close();

                baf.Obrada(y.kod, y.DumpingValue);

                Thread.Sleep(2000);
            }
        }
    }
}
