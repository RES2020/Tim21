using Biblioteka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class HistoricalLogovanje : ILogovanje
    {
        public void Loguj(string poruka)
        {
            string pr = Directory.GetCurrentDirectory();
            string projectDirectory2 = Directory.GetParent(pr).Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory2 + @"\Biblioteka", "Loger.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(poruka);
            sw.Close();
            stream.Close();
        }
    }
}
