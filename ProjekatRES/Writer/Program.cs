using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Biblioteka;
using DumpingBuffer;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Doktor/Documents/RES/ProjekatRES/Biblioteka/bin/Debug/DataW.txt";

            List<Code> kodovi = new List<Code>();
            List<Value> vrijednosti = new List<Value>();
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                kodovi.Add((Code)Enum.Parse(typeof(Code), tokens[0]));
                DateTime d = Convert.ToDateTime(tokens[1]);
                int id = Convert.ToInt32(tokens[2]);
                double dob = Convert.ToDouble(tokens[3]);
                Value v = new Value(d, id, dob);
                vrijednosti.Add(v);
            }
            sr.Close();
            stream.Close();

            

            Console.WriteLine("Saljem podatke DumpingBafferu...za 10 sec");
            Thread.Sleep(15000);

            int i = 0;
            foreach (Code item in kodovi)
            {
                string path1 = "C:/Users/Doktor/Documents/RES/ProjekatRES/DumpingBuffer/bin/Debug/Data.txt";


                FileStream stream1 = new FileStream(path1, FileMode.Append);
                StreamWriter sw = new StreamWriter(stream1);

                sw.WriteLine(item.ToString() + ";" + vrijednosti[i].timestamp.ToString() + ";" + vrijednosti[i].id + ";" + vrijednosti[i].potrosnja );
                sw.Close();
                stream1.Close();

                Console.WriteLine("Poslata vrijednost: Code -" + item.ToString() + " Value - " + vrijednosti[i].timestamp.ToString() + " " + vrijednosti[i].id + " " + vrijednosti[i].potrosnja);

                i++;

                Thread.Sleep(2000);
            }





        }
    }
}