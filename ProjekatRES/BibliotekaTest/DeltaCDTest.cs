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
    public class DeltaCDTest
    {

        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                List<DumpingProperty> lista1 = new List<DumpingProperty>();
                CollectionDescription cd1 = new CollectionDescription(133, 1, lista1);

                List<DumpingProperty> lista2 = new List<DumpingProperty>();
                CollectionDescription cd2 = new CollectionDescription(666, 3, lista2);

                List<DumpingProperty> lista3 = new List<DumpingProperty>();
                CollectionDescription cd3 = new CollectionDescription(167, 2, lista3);


                DeltaCD cd = new DeltaCD(21, cd1, cd2, cd3);
                yield return new TestCaseData(cd);
            }
        }
            [Test]
            [TestCaseSource("VRIJEDNOST")]
            public void TestKonstruktorDeltaCD(DeltaCD dc)
        {
            DeltaCD d = new DeltaCD(dc.transactionID, dc.Add, dc.Update, dc.Delete);

            Assert.AreEqual(d.transactionID,dc.transactionID);
            Assert.AreEqual(d.Add,dc.Add);
            Assert.AreEqual(d.Update, dc.Update);
            Assert.AreEqual(d.Delete, dc.Delete);
        }

    }
    }

