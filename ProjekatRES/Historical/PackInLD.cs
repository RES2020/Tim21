using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical
{
    public class PackInLD
    {
        public PackInLD()
        {

        }

        public void GetLD(DeltaCD data, LD l)
        {
            List<HistoricalProperty> forAdd = new List<HistoricalProperty>();
            foreach (DumpingProperty item in data.Add.DumpingPropertyCollection)
            {
                HistoricalProperty pr = new HistoricalProperty(item.kod, item.DumpingValue);
                forAdd.Add(pr);
            }
            Description descAdd = new Description(data.Add.id, forAdd, data.Add.dataset,"ADD");
            //ILogovanje Logovanje = new HistoricalLogovanje();
            //Logovanje.Loguj("Dodao u ADD: 1----"+ descAdd.props[0].kod+ Environment.NewLine + "2------" + descAdd.props[1].kod + Environment.NewLine);

            List<HistoricalProperty> forUpdate = new List<HistoricalProperty>();
            foreach (DumpingProperty item1 in data.Update.DumpingPropertyCollection)
            {
                HistoricalProperty pr1 = new HistoricalProperty(item1.kod, item1.DumpingValue);
                forUpdate.Add(pr1);
            }
            Description descUpdate = new Description(data.Update.id, forUpdate, data.Update.dataset,"UPDATE");
            //Logovanje.Loguj("Dodao u UPDATE: 1----" + descUpdate.props[0].kod + Environment.NewLine + "2------" + descUpdate.props[1].kod + Environment.NewLine);

            List<HistoricalProperty> forDelete = new List<HistoricalProperty>();
            foreach (DumpingProperty item2 in data.Delete.DumpingPropertyCollection)
            {
                HistoricalProperty pr2 = new HistoricalProperty(item2.kod, item2.DumpingValue);
                forDelete.Add(pr2);
            }
            Description descDelete = new Description(data.Delete.id, forDelete, data.Delete.dataset,"DELETE");
            //Logovanje.Loguj("Dodao u DELETE: 1----" + descDelete.props[0].kod + Environment.NewLine + "2------" + descDelete.props[1].kod + Environment.NewLine);

            if (forAdd != null)
            {
                l.list.Add(descAdd);
            }
            if (forUpdate != null)
            {
                l.list.Add(descUpdate);
            }
            if (forDelete!=null)
            {
                l.list.Add(descDelete);
            }
        }
    }
}
