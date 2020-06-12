using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class History
    {
        public List<Description> desc { get; set; }
        public History()
        {
            desc = new List<Description>();
        }
        public void Recive(DeltaCD data)
        {
            ILogovanje Logovanje = new HistoricalLogovanje();
            //string p = "dataset u deltacd add " + data.Add.dataset + " kod1= " + data.Add.DumpingPropertyCollection[0].kod.ToString() + " kod2= " + data.Add.DumpingPropertyCollection[1].kod.ToString() + Environment.NewLine;
            //Logovanje.Loguj(p);

            using (RESBazaEntities context = new RESBazaEntities())
            {
                foreach (DumpingProperty d in data.Add.DumpingPropertyCollection)
                {
                    if (data.Add.dataset == 1)
                    {
                        Tabela1 ob1 = new Tabela1
                        {
                            Code = d.kod.ToString(),
                            Timestamp = d.DumpingValue.timestamp.ToShortDateString(),
                            ValueID = d.DumpingValue.id.ToString(),
                            Potrosnja = d.DumpingValue.potrosnja.ToString(),
                            VrijemeUpisa = DateTime.Now.ToShortTimeString()

                        };
                        context.Tabela1.Add(ob1);
                        context.SaveChanges();
                    }
                }
            }
            PackInLD pakovanje = new PackInLD();
            LD newData = pakovanje.GetLD(data);

            string poruka = "Primljen je novi DeltaCD sa TransactionID: " + data.transactionID + " i upakovan je u LD" +  Environment.NewLine;
            Logovanje.Loguj(poruka);


            ValidateDataset val = new ValidateDataset();
            //val.Validate(newData);
        }
    }
}
