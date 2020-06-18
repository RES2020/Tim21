using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class Get
    {
        public string Kod { get; set; }

        public Get(string k)
        {
            Kod = k;   
        }

        public string GetValue()
        {
            string str = "";
            var kontekst = new PodaciDBContext();
            Podaci p = kontekst.Tabela.FirstOrDefault(i => i.Code == Kod);


            if (p != null)
            {
                str = "Za trazeni kod - " + Kod + " pronadjena su vrijednosti: " + Environment.NewLine + "Timestamp: " + p.Timestamp + Environment.NewLine + "Id geografskog podrucja: " + p.AreaID + Environment.NewLine + "Potrosnja: " + p.Consumption + Environment.NewLine + "Vrijeme upisa: " + p.Time;
            }
            else
            {
                str = "Nema podatka sa tim kodom!";
            }
            return str;
        }
    }
}
