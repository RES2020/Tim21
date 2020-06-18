using Biblioteka;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaTest
{
    [TestFixture]
    public class DumpingProperyTest
    {
        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                yield return new TestCaseData(new DumpingProperty(Code.CODE_ANALOG,new Value(DateTime.Now,123,21.4)));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestKonstruktorDP(DumpingProperty dp)
        {
            DumpingProperty dup = new DumpingProperty(dp.kod, dp.DumpingValue);
            Assert.AreEqual(dup.kod, dp.kod);
            Assert.AreEqual(dup.DumpingValue, dp.DumpingValue);
        }


        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                yield return new TestCaseData(new DumpingProperty(Code.CODE_MULTIPLENODE, new Value(Convert.ToDateTime("1/3/2000"), 222, 71.4)));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestKonstruktorDP1(DumpingProperty dp)
        {
            DumpingProperty dup = new DumpingProperty(dp.kod, dp.DumpingValue);
            Assert.AreEqual(dup.kod, dp.kod);
            Assert.AreEqual(dup.DumpingValue, dp.DumpingValue);
        }
    }
}
