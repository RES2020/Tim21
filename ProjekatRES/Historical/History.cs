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
        public LD descs { get; set; }

        public History()
        {
            descs =new LD(new List<Description>());
        }
        public void Recive(DeltaCD data)
        {

            PackInLD pakovanje = new PackInLD();

            pakovanje.GetLD(data, descs);

            ILogovanje Logovanje = new HistoricalLogovanje();
            //string p = "dataset u deltacd add " + data.Add.dataset + " kod1= " + data.Add.DumpingPropertyCollection[0].kod.ToString() + " kod2= " + data.Add.DumpingPropertyCollection[1].kod.ToString() + Environment.NewLine;
            //Logovanje.Loguj(p);

            string poruka = "Primljen je novi DeltaCD sa TransactionID: " + data.transactionID + " i upakovan je u LD" + Environment.NewLine;
            Logovanje.Loguj(poruka);

            var context = new PodaciDBContext();

            foreach (Description d in descs.list)
            {
                if (d.use == "ADD")
                {
                    string k = d.props[0].kod.ToString();
                    Podaci p = context.Tabela.FirstOrDefault(i => i.Code == k);

                    if (p == null)
                    {
                        var podatak = new Podaci
                        {
                            Code = d.props[0].kod.ToString(),
                            Timestamp = d.props[0].HistoricalValue.timestamp.ToShortDateString(),
                            AreaID = d.props[0].HistoricalValue.id.ToString(),
                            Consumption = d.props[0].HistoricalValue.potrosnja.ToString(),
                            Time = DateTime.Now.ToShortTimeString()
                        };
                        context.Tabela.Add(podatak);
                        context.SaveChanges();
                    }
                    //else
                    //{
                    //    if (d.props[0].kod == Code.CODE_DIGITAL)
                    //    {
                    //        var podatak = new Podaci
                    //        {
                    //            Code = d.props[0].kod.ToString(),
                    //            Timestamp = d.props[0].HistoricalValue.timestamp.ToShortDateString(),
                    //            AreaID = d.props[0].HistoricalValue.id.ToString(),
                    //            Consumption = d.props[0].HistoricalValue.potrosnja.ToString(),
                    //            Time = DateTime.Now.ToShortTimeString()
                    //        };
                    //        context.Tabela.Add(podatak);
                    //        context.SaveChanges();
                    //    }
                    //    else if ((Convert.ToDouble(p.Consumption) + (Convert.ToDouble(p.Consumption)) / 50) < d.props[0].HistoricalValue.potrosnja)
                    //    {
                    //        var podatak = new Podaci
                    //        {
                    //            Code = d.props[0].kod.ToString(),
                    //            Timestamp = d.props[0].HistoricalValue.timestamp.ToShortDateString(),
                    //            AreaID = d.props[0].HistoricalValue.id.ToString(),
                    //            Consumption = d.props[0].HistoricalValue.potrosnja.ToString(),
                    //            Time = DateTime.Now.ToShortTimeString()
                    //        };
                    //        context.Tabela.Add(podatak);
                    //        context.SaveChanges();
                    //    }
                    //}


                    string k1 = d.props[1].kod.ToString();
                    Podaci p1 = context.Tabela.FirstOrDefault(i => i.Code == k1);
                    if (p1 == null)
                    {
                        var podatak = new Podaci
                        {
                            Code = d.props[1].kod.ToString(),
                            Timestamp = d.props[1].HistoricalValue.timestamp.ToShortDateString(),
                            AreaID = d.props[1].HistoricalValue.id.ToString(),
                            Consumption = d.props[1].HistoricalValue.potrosnja.ToString(),
                            Time = DateTime.Now.ToShortTimeString()
                        };
                        context.Tabela.Add(podatak);
                        context.SaveChanges();
                    }
                    //else
                    //{
                    //    if (d.props[1].kod == Code.CODE_DIGITAL)
                    //    {
                    //        var podatak = new Podaci
                    //        {
                    //            Code = d.props[1].kod.ToString(),
                    //            Timestamp = d.props[1].HistoricalValue.timestamp.ToShortDateString(),
                    //            AreaID = d.props[1].HistoricalValue.id.ToString(),
                    //            Consumption = d.props[1].HistoricalValue.potrosnja.ToString(),
                    //            Time = DateTime.Now.ToShortTimeString()
                    //        };
                    //        context.Tabela.Add(podatak);
                    //        context.SaveChanges();
                    //    }
                    //    if ((Convert.ToDouble(p1.Consumption) + (Convert.ToDouble(p1.Consumption)) / 50) < d.props[1].HistoricalValue.potrosnja)
                    //    {
                    //        var podatak = new Podaci
                    //        {
                    //            Code = d.props[1].kod.ToString(),
                    //            Timestamp = d.props[1].HistoricalValue.timestamp.ToShortDateString(),
                    //            AreaID = d.props[1].HistoricalValue.id.ToString(),
                    //            Consumption = d.props[1].HistoricalValue.potrosnja.ToString(),
                    //            Time = DateTime.Now.ToShortTimeString()
                    //        };
                    //        context.Tabela.Add(podatak);
                    //        context.SaveChanges();
                    //    }
                    //}
                }
                else if (d.use == "UPDATE")
                {
                    if (d.props.Count()!=0 && d.props!=null)
                    {
                        string k = d.props[0].kod.ToString();
                        Podaci p = context.Tabela.FirstOrDefault(i => i.Code == k);

                        if (p != null)
                        {
                            if (d.props[0].kod == Code.CODE_DIGITAL)
                            {
                                p.Timestamp = d.props[0].HistoricalValue.timestamp.ToShortDateString();
                                p.AreaID = d.props[0].HistoricalValue.id.ToString();
                                p.Consumption = d.props[0].HistoricalValue.potrosnja.ToString();
                                p.Time = DateTime.Now.ToShortTimeString();
                                context.SaveChanges();
                            }
                            else
                            {
                                if ((Convert.ToDouble(p.Consumption) + (Convert.ToDouble(p.Consumption)) / 50) < d.props[0].HistoricalValue.potrosnja)
                                {
                                    p.Timestamp = d.props[0].HistoricalValue.timestamp.ToShortDateString();
                                    p.AreaID = d.props[0].HistoricalValue.id.ToString();
                                    p.Consumption = d.props[0].HistoricalValue.potrosnja.ToString();
                                    p.Time = DateTime.Now.ToShortTimeString();
                                    context.SaveChanges();
                                }
                            }
                        }

                        string k1 = d.props[1].kod.ToString();
                        Podaci p1 = context.Tabela.FirstOrDefault(i => i.Code == k1);

                        if (p1 != null)
                        {
                            if (d.props[1].kod == Code.CODE_DIGITAL)
                            {
                                p1.Timestamp = d.props[1].HistoricalValue.timestamp.ToShortDateString();
                                p1.AreaID = d.props[1].HistoricalValue.id.ToString();
                                p1.Consumption = d.props[1].HistoricalValue.potrosnja.ToString();
                                p1.Time = DateTime.Now.ToShortTimeString();
                                context.SaveChanges();
                            }
                            else
                            {
                                if ((Convert.ToDouble(p1.Consumption) + (Convert.ToDouble(p1.Consumption)) / 50) < d.props[1].HistoricalValue.potrosnja)
                                {
                                    p1.Timestamp = d.props[1].HistoricalValue.timestamp.ToShortDateString();
                                    p1.AreaID = d.props[1].HistoricalValue.id.ToString();
                                    p1.Consumption = d.props[1].HistoricalValue.potrosnja.ToString();
                                    p1.Time = DateTime.Now.ToShortTimeString();
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else if (d.use=="DELETE")
                {
                    if (d.props.Count() != 0 && d.props != null)
                    {
                        string k = d.props[0].kod.ToString();
                        Podaci p = context.Tabela.FirstOrDefault(i => i.Code == k);

                        if (p != null)
                        {
                            context.Tabela.Remove(p);
                            context.SaveChanges();
                        }

                        string k1 = d.props[1].kod.ToString();
                        Podaci p1 = context.Tabela.FirstOrDefault(i => i.Code == k1);

                        if (p1 != null)
                        {
                            context.Tabela.Remove(p1);
                            context.SaveChanges();
                        }
                    }
                }
            }

            descs.list.Clear();

        }

        public void CleanTable(PodaciDBContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Podacis");
            
        }
    }
}
