using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class Manual
    {
        public string kod { get; set; }
        public string datum { get; set; }
        public string id { get; set; }
        public string potrosnja { get; set; }

        public Manual(string k, string d,string i,string p)
        {
            kod = k;
            id = i;
            datum = d;
            potrosnja = p;
        }


        public void ManualWriteToHistory()
        {
            var konti = new PodaciDBContext();

            Podaci p = konti.Tabela.FirstOrDefault(i => i.Code == kod);
            if (p == null)
            {
                var novi = new Podaci
                {
                    Code = kod,
                    Timestamp = datum,
                    AreaID = id,
                    Consumption = potrosnja,
                    Time = DateTime.Now.ToShortTimeString()

                };
                konti.Tabela.Add(novi);
                konti.SaveChanges();
            }
            else
            {
                p.Timestamp = datum;
                p.AreaID = id;
                p.Consumption = potrosnja;
                p.Time = DateTime.Now.ToShortTimeString();
            }
            konti.SaveChanges();

        }
    }
}
