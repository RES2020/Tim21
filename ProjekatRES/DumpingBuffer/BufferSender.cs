using Biblioteka;
using Historical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class BufferSender
    {
        public BufferSender()
        {

        }

        public void SendToHistory(List<DeltaCD> lista)
        {
            foreach (DeltaCD d in lista)
            {
                History Hist = new History();
                Hist.Recive(d);
            }
        }
    }
}
