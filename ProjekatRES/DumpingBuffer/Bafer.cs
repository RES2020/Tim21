using Biblioteka;
//using Historical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class Bafer
    {

        //public List<DumpingProperty> DumpingPropertyCollection { get; set; }
        //History Hist { get; set; }
        public List<CollectionDescription> CDS { get; set; }
        public int counter;

        public void dodavanjeCD(int set, DumpingProperty data, ILogovanje Loger)
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
                            poruka= "Azurirana vrijednost u DumpingBufferu. Dataset: " + set + " Code: " + data.kod + " Value: " +  data.DumpingValue.timestamp + " " + data.DumpingValue.id + " " + data.DumpingValue.potrosnja + Environment.NewLine;
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
                        poruka= "Dodat je novi DumpingProperty u postojeci CD. Dataset: " + set + " Code: " + data.kod + " Value: " + data.DumpingValue.timestamp + " " + data.DumpingValue.id + " " + data.DumpingValue.potrosnja + Environment.NewLine;
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

        public Bafer()
        {
            CDS = new List<CollectionDescription>();
            counter = 0;
            //Hist = new History();
        }

        public void Obrada(Code kod,Value vrijednost)
        {
            Random rId = new Random();
            int dataset = -1;

            DumpingProperty dp = new DumpingProperty(kod, vrijednost);

            if(dp.kod == Code.CODE_ANALOG || dp.kod == Code.CODE_DIGITAL)
            {
                dataset = 1;
            }else if(dp.kod == Code.CODE_CUSTOM || dp.kod == Code.CODE_LIMITSET)
            {
                dataset = 2;
            }else if(dp.kod ==  Code.CODE_SINGLENODE || dp.kod==Code.CODE_MULTIPLENODE)
            {
                dataset = 3;
            }else if(dp.kod == Code.CODE_CONSUMER || dp.kod == Code.CODE_SOURCE)
            {
                dataset = 4;
            }
            else
            {
                dataset = 5;
            }

            string poruka = "DumpingBuffer primio podatak.Code = " + Environment.NewLine + dp.kod.ToString() + "Value = " + dp.DumpingValue.timestamp.ToString() + " " + dp.DumpingValue.id + " " + dp.DumpingValue.potrosnja + Environment.NewLine;

            ILogovanje Logovanje = new DumpingLogovanje();
            Logovanje.Loguj(poruka);

            dodavanjeCD(dataset, dp,Logovanje);
            counter++;

            if (counter == 10)
            {
                counter = 0;
                int brojac = 0;
                Random br = new Random();
                string porukaDC = "Primljeno 10 podataka! Pocinje pakovanje."+ Environment.NewLine;
                Logovanje.Loguj(porukaDC);
                List<DeltaCD> DeltaCDS = new List<DeltaCD>();

                foreach(CollectionDescription c in CDS)
                {
                     if (c.poslat==false && c.DumpingPropertyCollection.Count() == 2)
                     {
                        c.poslat = true;

                        if (brojac == 0)
                        {
                            DeltaCD zaSlanje = new DeltaCD(br.Next(1000, 100000), new CollectionDescription(-1, -1, new List<DumpingProperty>()), new CollectionDescription(-1, -1, new List<DumpingProperty>()), new CollectionDescription(-1, -1, new List<DumpingProperty>()));
                            zaSlanje.Add = c;
                            DeltaCDS.Add(zaSlanje);
                            brojac++;
                            porukaDC = "Ubacen Add u DC. ID:"+ zaSlanje.transactionID+Environment.NewLine + zaSlanje.Add.DumpingPropertyCollection[0].kod.ToString()+ " " + zaSlanje.Add.DumpingPropertyCollection[0].DumpingValue.timestamp.ToString()+ " " + zaSlanje.Add.DumpingPropertyCollection[0].DumpingValue.id+ " " + zaSlanje.Add.DumpingPropertyCollection[0].DumpingValue.potrosnja + Environment.NewLine + zaSlanje.Add.DumpingPropertyCollection[1].kod.ToString() + " " + zaSlanje.Add.DumpingPropertyCollection[1].DumpingValue.timestamp.ToString() + " " + zaSlanje.Add.DumpingPropertyCollection[1].DumpingValue.id + " " + zaSlanje.Add.DumpingPropertyCollection[1].DumpingValue.potrosnja + Environment.NewLine;
                            Logovanje.Loguj(porukaDC);
                        }
                        else if (brojac == 1)
                        {
                            DeltaCDS[0].Update = c;
                            brojac++;
                            porukaDC = "Ubacen Update u DC. ID:" + DeltaCDS[0].transactionID + Environment.NewLine + DeltaCDS[0].Update.DumpingPropertyCollection[0].kod.ToString() + " " + DeltaCDS[0].Update.DumpingPropertyCollection[0].DumpingValue.timestamp.ToString() + " " + DeltaCDS[0].Update.DumpingPropertyCollection[0].DumpingValue.id + " " + DeltaCDS[0].Update.DumpingPropertyCollection[0].DumpingValue.potrosnja + Environment.NewLine + DeltaCDS[0].Update.DumpingPropertyCollection[1].kod.ToString() + " " + DeltaCDS[0].Update.DumpingPropertyCollection[1].DumpingValue.timestamp.ToString() + " " + DeltaCDS[0].Update.DumpingPropertyCollection[1].DumpingValue.id + " " + DeltaCDS[0].Update.DumpingPropertyCollection[1].DumpingValue.potrosnja + Environment.NewLine;
                            Logovanje.Loguj(porukaDC);
                        }
                        else if (brojac == 2)
                        {
                            DeltaCDS[0].Delete = c;
                            brojac++;
                            porukaDC = "Ubacen Delete u DC. ID:" + DeltaCDS[0].transactionID + Environment.NewLine + DeltaCDS[0].Delete.DumpingPropertyCollection[0].kod.ToString() + " " + DeltaCDS[0].Delete.DumpingPropertyCollection[0].DumpingValue.timestamp.ToString() + " " + DeltaCDS[0].Delete.DumpingPropertyCollection[0].DumpingValue.id + " " + DeltaCDS[0].Delete.DumpingPropertyCollection[0].DumpingValue.potrosnja + Environment.NewLine + DeltaCDS[0].Delete.DumpingPropertyCollection[1].kod.ToString() + " " + DeltaCDS[0].Delete.DumpingPropertyCollection[1].DumpingValue.timestamp.ToString() + " " + DeltaCDS[0].Delete.DumpingPropertyCollection[1].DumpingValue.id + " " + DeltaCDS[0].Delete.DumpingPropertyCollection[1].DumpingValue.potrosnja + Environment.NewLine;
                            Logovanje.Loguj(porukaDC);
                        }
                        else if (brojac == 3)
                        {
                            DeltaCD noviZaSlanje = new DeltaCD(br.Next(1000, 100000), new CollectionDescription(-1, -1, new List<DumpingProperty>()), new CollectionDescription(-1, -1, new List<DumpingProperty>()), new CollectionDescription(-1, -1, new List<DumpingProperty>()));
                            noviZaSlanje.Add = c;
                            DeltaCDS.Add(noviZaSlanje);
                            brojac++;
                            porukaDC = "Ubacen Add u DC. ID:" + noviZaSlanje.transactionID + Environment.NewLine + noviZaSlanje.Add.DumpingPropertyCollection[0].kod.ToString() + " " + noviZaSlanje.Add.DumpingPropertyCollection[0].DumpingValue.timestamp.ToString() + " " + noviZaSlanje.Add.DumpingPropertyCollection[0].DumpingValue.id + " " + noviZaSlanje.Add.DumpingPropertyCollection[0].DumpingValue.potrosnja + Environment.NewLine + noviZaSlanje.Add.DumpingPropertyCollection[1].kod.ToString() + " " + noviZaSlanje.Add.DumpingPropertyCollection[1].DumpingValue.timestamp.ToString() + " " + noviZaSlanje.Add.DumpingPropertyCollection[1].DumpingValue.id + " " + noviZaSlanje.Add.DumpingPropertyCollection[1].DumpingValue.potrosnja + Environment.NewLine;
                            Logovanje.Loguj(porukaDC);
                        }
                        else if (brojac == 4)
                        {
                            DeltaCDS[1].Update = c;
                            brojac++;
                            porukaDC = "Ubacen Update u DC. ID:" + DeltaCDS[1].transactionID + Environment.NewLine + DeltaCDS[1].Update.DumpingPropertyCollection[0].kod.ToString() + " " + DeltaCDS[1].Update.DumpingPropertyCollection[0].DumpingValue.timestamp.ToString() + " " + DeltaCDS[1].Update.DumpingPropertyCollection[0].DumpingValue.id + " " + DeltaCDS[1].Update.DumpingPropertyCollection[0].DumpingValue.potrosnja + Environment.NewLine + DeltaCDS[1].Update.DumpingPropertyCollection[1].kod.ToString() + " " + DeltaCDS[1].Update.DumpingPropertyCollection[1].DumpingValue.timestamp.ToString() + " " + DeltaCDS[1].Update.DumpingPropertyCollection[1].DumpingValue.id + " " + DeltaCDS[1].Update.DumpingPropertyCollection[1].DumpingValue.potrosnja + Environment.NewLine;
                            Logovanje.Loguj(porukaDC);
                        }
                        else
                        {
                            Console.WriteLine("Polaganje Res-a");
                        }
                     }
                 }
                foreach (DeltaCD d in DeltaCDS)
                {
                    //Hist.Recive(d);
                }
            }
        }
    }
}
