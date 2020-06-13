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

            var context = new PodaciDBContext();

            //Podaci p = (from po in context.Tabela where po.Code=="CODE_ANALOG" select po).Single();
            //p.Consumption = "1010";
            //context.SaveChanges();
           foreach(DumpingProperty dup in data.Add.DumpingPropertyCollection)
            {
                var podatak = new Podaci
                {

                    Code = dup.kod.ToString(),
                    Timestamp = dup.DumpingValue.timestamp.ToShortDateString(),
                    AreaID = dup.DumpingValue.id.ToString(),
                    Consumption = dup.DumpingValue.potrosnja.ToString(),
                    Time = DateTime.Now.ToShortTimeString()

                };
                context.Tabela.Add(podatak);
                context.SaveChanges();
            }

            foreach (DumpingProperty dup in data.Update.DumpingPropertyCollection)
            {
                var podatak = new Podaci
                {

                    Code = dup.kod.ToString(),
                    Timestamp = dup.DumpingValue.timestamp.ToShortDateString(),
                    AreaID = dup.DumpingValue.id.ToString(),
                    Consumption = dup.DumpingValue.potrosnja.ToString(),
                    Time = DateTime.Now.ToShortTimeString()

                };
                context.Tabela.Add(podatak);
                context.SaveChanges();
            }

            foreach (DumpingProperty dup in data.Delete.DumpingPropertyCollection)
            {
                var podatak = new Podaci
                {

                    Code = dup.kod.ToString(),
                    Timestamp = dup.DumpingValue.timestamp.ToShortDateString(),
                    AreaID = dup.DumpingValue.id.ToString(),
                    Consumption = dup.DumpingValue.potrosnja.ToString(),
                    Time = DateTime.Now.ToShortTimeString()

                };
                context.Tabela.Add(podatak);
                context.SaveChanges();
            }

            PackInLD pakovanje = new PackInLD();
            LD newData = pakovanje.GetLD(data);

            string poruka = "Primljen je novi DeltaCD sa TransactionID: " + data.transactionID + " i upakovan je u LD" +  Environment.NewLine;
            Logovanje.Loguj(poruka);


            ValidateDataset val = new ValidateDataset();
            //val.Validate(newData);
        }

        public void CleanTable(PodaciDBContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Podacis");
            
        }
    }
}
