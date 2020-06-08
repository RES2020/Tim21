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

            string pr = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(pr).Parent.FullName;
            string path = Path.Combine(projectDirectory, "DataW.txt");

            string projectDirectory2 = Directory.GetParent(pr).Parent.Parent.FullName;
            string path1 = Path.Combine(projectDirectory2 + @"\DumpingBuffer", "Data.txt");


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

            

            Console.WriteLine("Saljem podatke DumpingBafferu...za 5 sec");
            Thread.Sleep(5000);

            int i = 0;
            foreach (Code item in kodovi)
            {
                string poruka = "Writer poslao podatke: Code: " + item.ToString() + " Value: " + vrijednosti[i].timestamp + " " + vrijednosti[i].id + " " + vrijednosti[i].potrosnja + Environment.NewLine;
                string pr1 = Directory.GetCurrentDirectory();
                string projectDirectory3 = Directory.GetParent(pr1).Parent.Parent.FullName;
                string p = Path.Combine(projectDirectory3 + @"\Biblioteka", "Loger.txt");
                FileStream stream1 = new FileStream(p, FileMode.Append);
                StreamWriter sw = new StreamWriter(stream1);
                sw.WriteLine(poruka);
                sw.Close();
                stream1.Close();
                Bafer.Obrada(item, vrijednosti[i]);
                
                i++;

                Thread.Sleep(2000);
            }





        }
    }
}