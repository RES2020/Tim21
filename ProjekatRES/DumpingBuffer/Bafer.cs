using Biblioteka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public static class Bafer
    {
        public static void Obrada(Code kod,Value vrijednost)
        {
            List<DumpingProperty> DumpingPropertyCollection = new List<DumpingProperty>();
            int dataset = -1;

            DumpingProperty dp = new DumpingProperty(kod, vrijednost);

            if(dp.kod == Code.CODE_ANALOG || dp.kod == Code.CODE_DIGITAL)
            {
                dataset = 1;
            }else if(dp.kod == Code.CODE_CUSTOM || dp.kod == Code.CODE_LIMITSET)
            {
                dataset = 2;
            }else if(dp.kod ==  Code.CODE_SINGLENODE || dp.kod==Code.CODE_MULTIPLENODE)
            {
                dataset = 3;
            }else if(dp.kod == Code.CODE_CONSUMER || dp.kod == Code.CODE_SOURCE)
            {
                dataset = 4;
            }
            else
            {
                dataset = 5;
            }

            string poruka = "DumpingBuffer primio podatak.Code = " + Environment.NewLine + dp.kod.ToString() + "Value = " + dp.DumpingValue.timestamp.ToString() + " " + dp.DumpingValue.id + " " + dp.DumpingValue.potrosnja + Environment.NewLine;

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
