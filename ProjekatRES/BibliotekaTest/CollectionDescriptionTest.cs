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
    public class CollectionDescriptionTest
    {
        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {

                List<DumpingProperty> lista = new List<DumpingProperty>();
                yield return new TestCaseData(new CollectionDescription(133,1,lista));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestKonstruktorCollectionDescription(CollectionDescription cd)
        {
            CollectionDescription c = new CollectionDescription(cd.id,cd.dataset,cd.DumpingPropertyCollection);

            Assert.AreEqual(c.id,cd.id);
            Assert.AreEqual(c.dataset,cd.dataset);
            Assert.AreEqual(c.DumpingPropertyCollection,cd.DumpingPropertyCollection);
        }

        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {

                List<DumpingProperty> lista = new List<DumpingProperty>();
                lista.Add(new DumpingProperty(Code.CODE_CONSUMER,new Value(DateTime.Now,432,14.6)));
                yield return new TestCaseData(new CollectionDescription(333, 4, lista));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestKonstruktorCollectionDescription1(CollectionDescription cd)
        {
            CollectionDescription c = new CollectionDescription(cd.id, cd.dataset, cd.DumpingPropertyCollection);

            Assert.AreEqual(c.id, cd.id);
            Assert.AreEqual(c.dataset, cd.dataset);
            Assert.AreEqual(c.DumpingPropertyCollection, cd.DumpingPropertyCollection);
        }

    }
}
