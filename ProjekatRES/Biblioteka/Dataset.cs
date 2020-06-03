using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Dataset
    {
        public List<Code> dataset1 = new List<Code>();
        public List<Code> dataset2 = new List<Code>();
        public List<Code> dataset3 = new List<Code>();
        public List<Code> dataset4 = new List<Code>();
        public List<Code> dataset5 = new List<Code>();

        public Dataset() {


            dataset1.Add(Code.CODE_ANALOG);
            dataset1.Add(Code.CODE_DIGITAL);
            dataset2.Add(Code.CODE_CUSTOM);
            dataset2.Add(Code.CODE_LIMITSET);
            dataset3.Add(Code.CODE_SINGLENODE);
            dataset3.Add(Code.CODE_MULTIPLENODE);
            dataset4.Add(Code.CODE_CONSUMER);
            dataset4.Add(Code.CODE_SOURCE);
            dataset5.Add(Code.CODE_MOTION);
            dataset5.Add(Code.CODE_SENSOR);
        }

    }

}
