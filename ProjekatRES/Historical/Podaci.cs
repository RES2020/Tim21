using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class Podaci
    {
        public int id { get; set; }
        public string Code { get; set; }
        public string Timestamp { get; set; }
        public string AreaID { get; set; }
        public string Consumption { get; set; }
        public string Time { get; set; }
        }

    public class PodaciDBContext:DbContext
    {
        public DbSet<Podaci> Tabela { get; set; }
       
    }

    

}

