using Biblioteka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DumpingProperty> DumpingPropertyCollection = new List<DumpingProperty>();
            Random r = new Random();
            int data;


            //CollectionDescription cd1 = new CollectionDescription(r.Next(), DumpingPropertyCollection, 1);
            //CollectionDescription cd2 = new CollectionDescription(r.Next(), DumpingPropertyCollection, 2);
            //CollectionDescription cd3 = new CollectionDescription(r.Next(), DumpingPropertyCollection, 3);
            //CollectionDescription cd4 = new CollectionDescription(r.Next(), DumpingPropertyCollection, 4);
            //CollectionDescription cd5 = new CollectionDescription(r.Next(), DumpingPropertyCollection, 5);

            string pr = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(pr).Parent.FullName;
            string path = Path.Combine(projectDirectory, "Data.txt");


            while (true)
            {


               

                if (new FileInfo(path).Length != 0)
                {

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



                    Value val = vrijednosti.First();
                    Code k = kodovi.First();

                    FileStream s = new FileStream(path, FileMode.Create);
                    s.Close();

                    Console.WriteLine("Primljen je novi podatak.Value:" + Environment.NewLine + val.timestamp.ToString() + " " + val.id + " " + val.potrosnja + Environment.NewLine + "Code:" + k.ToString());
                  
                    //obrardi(data);

                }
                }
            }
        }
    }

