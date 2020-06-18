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
    public class DescriptionTest
    {

        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                Value val = new Value(DateTime.Now, 123, 55.6);
                HistoricalProperty hp = new HistoricalProperty(Code.CODE_LIMITSET, val);
                List<HistoricalProperty> lista = new List<HistoricalProperty>();
                lista.Add(hp);
                Description desc = new Description(3, lista, 3, "DELETE");
                yield return new TestCaseData(desc);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestKonstruktorDescription(Description desc)
        {
            Description d = new Description(desc.id,desc.props,desc.dataset,desc.use);
            Assert.AreEqual(d.id,desc.id);
            Assert.AreEqual(d.props, desc.props);
            Assert.AreEqual(d.dataset, desc.dataset);
            Assert.AreEqual(d.use, desc.use);
        }


        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                Value val = new Value(Convert.ToDateTime("2/6/2019"), 543, 15.3);
                HistoricalProperty hp = new HistoricalProperty(Code.CODE_MULTIPLENODE, val);
                List<HistoricalProperty> lista = new List<HistoricalProperty>();
                lista.Add(hp);
                Description desc = new Description(23, lista, 5, "ADD");
                yield return new TestCaseData(desc);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestKonstruktorDescription1(Description desc)
        {
            Description d = new Description(desc.id, desc.props, desc.dataset, desc.use);
            Assert.AreEqual(d.id, desc.id);
            Assert.AreEqual(d.props, desc.props);
            Assert.AreEqual(d.dataset, desc.dataset);
            Assert.AreEqual(d.use, desc.use);
        }
    }
}
