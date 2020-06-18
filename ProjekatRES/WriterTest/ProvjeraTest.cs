using Biblioteka;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer;

namespace WriterTest
{
    [TestFixture]
    public class ProvjeraTest
    {
        [Test]
        [TestCase("moze bilo sta")]
        [TestCase("  ")]
        public void TestProvjeraKonstruktor(string p)
        {
            Provjera pr = new Provjera(p);
            Assert.AreEqual(pr.kod, p);
        }
    }
}
