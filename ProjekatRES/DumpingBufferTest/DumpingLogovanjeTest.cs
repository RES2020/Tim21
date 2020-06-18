using Biblioteka;
using DumpingBuffer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBufferTest
{
    [TestFixture]
    public class DumpingLogovanjeTest
    {

        [Test]
        [TestCase("nesto za upis")]
        public void LogovanjeTest(string poruka)
        {
            ILogovanje log = new DumpingLogovanje();
            log.Obrisi();

            log.Loguj(poruka);

            string pr = Directory.GetCurrentDirectory();
            string projectDirectory2 = Directory.GetParent(pr).Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory2 + @"\Biblioteka", "Loger.txt");
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);

            string line = "";
            line = sr.ReadLine();

            sr.Close();
            stream.Close();

            Assert.AreEqual(poruka, line);
        }

        [Test]
        public void ObrisiTest()
        {
            ILogovanje loguj = new DumpingLogovanje();
            loguj.Obrisi();

            string pr = Directory.GetCurrentDirectory();
            string projectDirectory2 = Directory.GetParent(pr).Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory2 + @"\Biblioteka", "Loger.txt");
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);

            string line = "";
            line = sr.ReadLine();

            sr.Close();
            stream.Close();

            Assert.AreEqual(line,null);
        }
    }
}
