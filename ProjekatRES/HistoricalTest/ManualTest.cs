using Historical;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalTest
{
    public class ManualTest
    {
        [Test]
        [TestCase("CODE_DIGITAL","1/1/1998","123","99.3")]
        public void ManualKonstruktorTest(string kod,string datum,string id,string potrosnja)
        {
            Manual man = new Manual(kod,datum,id,potrosnja);

            Assert.AreEqual(man.kod, kod);
            Assert.AreEqual(man.datum,datum);
            Assert.AreEqual(man.id,id);
            Assert.AreEqual(man.potrosnja,potrosnja);
        }

        [Test]
        [TestCase("CODE_LIMITSET", "12/12/1967", "53", "100.4")]
        public void ManualKonstruktorTest1(string kod, string datum, string id, string potrosnja)
        {
            Manual man = new Manual(kod, datum, id, potrosnja);

            Assert.AreEqual(man.kod, kod);
            Assert.AreEqual(man.datum, datum);
            Assert.AreEqual(man.id, id);
            Assert.AreEqual(man.potrosnja, potrosnja);
        }

       
        
    }
}
