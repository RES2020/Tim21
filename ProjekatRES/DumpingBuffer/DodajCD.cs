using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class DodajCD
    {
        public DodajCD()
        {
                
        }

        public void Dodaj(int set,DumpingProperty data,ILogovanje Loger,List<CollectionDescription> CDS)
        {
            Random r = new Random();
            int x = 0;
            int y = 0;
            string poruka = "";
            string por2 = "";

            foreach (CollectionDescription cd in CDS)
            {
                if (cd.dataset == set)
                {
                    y = 1;
                    foreach (DumpingProperty dp in cd.DumpingPropertyCollection)
                    {
                        if (dp.kod.Equals(data.kod))
                        {
                            dp.DumpingValue = data.DumpingValue;
                            x = 1;
                            poruka = "Azurirana vrijednost u DumpingBufferu. Dataset: " + set + " Code: " + data.kod + " Value: " + data.DumpingValue.timestamp + " " + data.DumpingValue.id + " " + data.DumpingValue.potrosnja + Environment.NewLine;
                            Loger.Loguj(poruka);
                            por2 = "Novi izgled CD-a sa ID:" + cd.id + " DataSet:" + cd.dataset + Environment.NewLine;
                            foreach (DumpingProperty item in cd.DumpingPropertyCollection)
                            {
                                por2 += "Dumping Property:" + item.kod + " " + item.DumpingValue.timestamp + " " + item.DumpingValue.id + " " + item.DumpingValue.potrosnja + Environment.NewLine;
                            }
                            Loger.Loguj(por2);

                        }

                    }
                    if (x == 0)
                    {
                        cd.DumpingPropertyCollection.Add(data);
                        poruka = "Dodat je novi DumpingProperty u postojeci CD. Dataset: " + set + " Code: " + data.kod + " Value: " + data.DumpingValue.timestamp + " " + data.DumpingValue.id + " " + data.DumpingValue.potrosnja + Environment.NewLine;
                        Loger.Loguj(poruka);
                        por2 = "Novi izgled CD-a sa ID:" + cd.id + " DataSet:" + cd.dataset + Environment.NewLine;
                        foreach (DumpingProperty item in cd.DumpingPropertyCollection)
                        {
                            por2 += "Dumping Property:" + item.kod + " " + item.DumpingValue.timestamp + " " + item.DumpingValue.id + " " + item.DumpingValue.potrosnja + Environment.NewLine;
                        }
                        Loger.Loguj(por2);
                    }
                }
            }
            if (y == 0)
            {

                List<DumpingProperty> dpc = new List<DumpingProperty>();
                dpc.Add(data);
                int id = r.Next(1000, 100000);
                CollectionDescription novi = new CollectionDescription(id, set, dpc);
                CDS.Add(novi);
                poruka = "Dodat je novi CD. ID: " + id + " DataSet: " + set + Environment.NewLine;
                Loger.Loguj(poruka);
                por2 = "Novi izgled CD-a sa ID:" + novi.id + " DataSet:" + novi.dataset + Environment.NewLine;
                foreach (DumpingProperty item in novi.DumpingPropertyCollection)
                {
                    por2 += "Dumping Property:" + item.kod + " " + item.DumpingValue.timestamp + " " + item.DumpingValue.id + " " + item.DumpingValue.potrosnja + Environment.NewLine;
                }
                Loger.Loguj(por2);
            }

        }
    }
}
