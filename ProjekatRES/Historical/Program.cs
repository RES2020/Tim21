using Biblioteka;
using DumpingBuffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    class Program
    {

        public Value GetChangesForInterval(Code kod)
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
            {
                //citanje iz fajla,dobavljanje podataka ide ovde
                DeltaCD data = new DeltaCD();

                List<HistoricalProperty> forAdd = new List<HistoricalProperty>();
                foreach (DumpingProperty item in data.Add.DumpingPropertyCollection)
                {
                    HistoricalProperty pr = new HistoricalProperty(item.kod, item.DumpingValue);
                    forAdd.Add(pr);
                }
                Description descAdd = new Description(data.Add.id, forAdd, data.Add.dataset);

                List<HistoricalProperty> forUpdate = new List<HistoricalProperty>();
                foreach (DumpingProperty item1 in data.Update.DumpingPropertyCollection)
                {
                    HistoricalProperty pr1 = new HistoricalProperty(item1.kod, item1.DumpingValue);
                    forUpdate.Add(pr1);
                }
                Description descUpdate = new Description(data.Update.id, forUpdate, data.Update.dataset);

                List<HistoricalProperty> forDelete = new List<HistoricalProperty>();
                foreach (DumpingProperty item2 in data.Delete.DumpingPropertyCollection)
                {
                    HistoricalProperty pr2 = new HistoricalProperty(item2.kod, item2.DumpingValue);
                    forUpdate.Add(pr2);
                }
                Description descDelete = new Description(data.Delete.id, forDelete, data.Delete.dataset);

                List<Description> lista = new List<Description>();
                LD newData = new LD(lista);
            }
        }
    }

