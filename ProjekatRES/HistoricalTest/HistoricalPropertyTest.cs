using Biblioteka;
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
    public class HistoricalPropertyTest
    {
        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                Value val = new Value(DateTime.Now,123,55.6);
                HistoricalProperty hp = new HistoricalProperty(Code.CODE_LIMITSET, val);
                yield return new TestCaseData(hp);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestKonstruktorHistoricalProperty(HistoricalProperty val)
        {
            HistoricalProperty hp = new HistoricalProperty(val.kod, val.HistoricalValue);
            Assert.AreEqual(hp.kod, val.kod);
            Assert.AreEqual(hp.HistoricalValue,val.HistoricalValue);
        }


        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                Value val = new Value(DateTime.Now, 443, 95.6);
                HistoricalProperty hp = new HistoricalProperty(Code.CODE_SENSOR, val);
                yield return new TestCaseData(hp);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestKonstruktorHistoricalProperty1(HistoricalProperty val)
        {
            HistoricalProperty hp = new HistoricalProperty(val.kod, val.HistoricalValue);
            Assert.AreEqual(hp.kod, val.kod);
            Assert.AreEqual(hp.HistoricalValue, val.HistoricalValue);
        }
    }
}
