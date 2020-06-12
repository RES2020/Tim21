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

        
        public List<CollectionDescription> CDS { get; set; }
        public int counter;



        public Bafer()
        {
            CDS = new List<CollectionDescription>();
            counter = 0;
            
        }

        public void Obrada(Code kod,Value vrijednost)
        {
            Random rId = new Random();
            int dataset = -1;

            DumpingProperty dp = new DumpingProperty(kod, vrijednost);
            Dataset da = new Dataset();
            dataset = da.GetDataset(kod);
            

            string poruka = "DumpingBuffer primio podatak.Code = " + Environment.NewLine + dp.kod.ToString() + "Value = " + dp.DumpingValue.timestamp.ToString() + " " + dp.DumpingValue.id + " " + dp.DumpingValue.potrosnja + Environment.NewLine;

            ILogovanje Logovanje = new DumpingLogovanje();
            Logovanje.Loguj(poruka);

            
            DodajCD dodajCD = new DodajCD();
            dodajCD.Dodaj(dataset, dp, Logovanje, CDS);
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
                BufferSender bufi = new BufferSender();
                bufi.SendToHistory(DeltaCDS);
            }
        }
    }
}
