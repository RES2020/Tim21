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
    
    public class ValueTest
    {
        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                yield return new TestCaseData(new Value(DateTime.Now, 123, 55.6));
            }
        }
        
        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestKonstruktorValue(Value val)
        {
            Value v = new Value(val.timestamp, val.id, val.potrosnja);
            Assert.AreEqual(v.timestamp,val.timestamp);
            Assert.AreEqual(v.id, val.id);
            Assert.AreEqual(v.potrosnja, val.potrosnja);
        }

        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                yield return new TestCaseData(new Value(Convert.ToDateTime("1/4/2019"), 666, 25.9));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestKonstruktorValue1(Value val)
        {
            Value v = new Value(val.timestamp, val.id, val.potrosnja);
            Assert.AreEqual(v.timestamp, val.timestamp);
            Assert.AreEqual(v.id, val.id);
            Assert.AreEqual(v.potrosnja, val.potrosnja);
        }
    }
}
