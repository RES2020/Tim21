using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public class Provjera
    {
        public string kod { get; set; }
        public string areaID { get; set; }
        public string potrosnja { get; set; }
       

        public Provjera(string k/*,string a,string p*/)
        {
            kod = k;
            //areaID = a;
            //potrosnja = p;
        }


        public bool Validnost()
        {
            if (kod.Equals(Code.CODE_ANALOG.ToString()) && kod.Equals(Code.CODE_DIGITAL.ToString()) && kod.Equals(Code.CODE_CONSUMER.ToString()) && kod.Equals(Code.CODE_CUSTOM.ToString()) && kod.Equals( Code.CODE_LIMITSET.ToString()) && kod.Equals( Code.CODE_MOTION.ToString()) && kod.Equals(Code.CODE_MULTIPLENODE.ToString()) && kod.Equals(Code.CODE_SENSOR.ToString()) && kod.Equals( Code.CODE_SINGLENODE.ToString()) && kod.Equals( Code.CODE_SOURCE.ToString()))
            {
                //Console.WriteLine("pao");
                return false;
            }
            

            //int id;
            //if (!int.TryParse(areaID, out id))
            //    return false;

            //double pot;
            //if (double.TryParse(potrosnja, out pot))
            //    return false;

            return true;
        }
    }
}
