using Historical;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalTest
{
    [TestFixture]
    public class LDTest
    {
        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                yield return new TestCaseData(new LD(new List<Description>()));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestKonstruktorLD(LD ld)
        {
            LD l = new LD(ld.list);
            Assert.AreEqual(l.list,ld.list);
        }

        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                List<HistoricalProperty> lista = new List<HistoricalProperty>();
                Description d = new Description(2,lista,4,"ADD");
                List<Description> list = new List<Description>();
                list.Add(d);
                yield return new TestCaseData(new LD(list));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestKonstruktorLD1(LD ld)
        {
            LD l = new LD(ld.list);
            Assert.AreEqual(l.list, ld.list);
        }
    }
}
