using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class Dataset
    {

        public Dataset()
        {
        }

        public int GetDataset(Code k)
        {
            int dataset = -1;
            if (k == Code.CODE_ANALOG || k == Code.CODE_DIGITAL)
            {
                dataset = 1;
            }
            else if (k == Code.CODE_CUSTOM || k == Code.CODE_LIMITSET)
            {
                dataset = 2;
            }
            else if (k == Code.CODE_SINGLENODE || k == Code.CODE_MULTIPLENODE)
            {
                dataset = 3;
            }
            else if (k == Code.CODE_CONSUMER || k == Code.CODE_SOURCE)
            {
                dataset = 4;
            }
            else
            {
                dataset = 5;
            }
            return dataset;
        }
    }
}
