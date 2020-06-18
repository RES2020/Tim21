using Biblioteka;
using DumpingBuffer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBufferTest
{
    public class DatasetTest
    {

        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                yield return new TestCaseData(Code.CODE_LIMITSET);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void GetDatasetTest(Code kod)
        {
            Dataset set = new Dataset();
            int result = set.GetDataset(kod);

            Assert.AreEqual(result, 2);
        }


        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                yield return new TestCaseData(Code.CODE_ANALOG);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void GetDatasetTest1(Code kod)
        {
            Dataset set = new Dataset();
            int result = set.GetDataset(kod);

            Assert.AreEqual(result, 1);
        }



        public static IEnumerable<TestCaseData> VRIJEDNOST2
        {
            get
            {
                yield return new TestCaseData(Code.CODE_SOURCE);
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST2")]
        public void GetDatasetTest2(Code kod)
        {
            Dataset set = new Dataset();
            int result = set.GetDataset(kod);

            Assert.AreEqual(result, 4);
        }

    }
}
