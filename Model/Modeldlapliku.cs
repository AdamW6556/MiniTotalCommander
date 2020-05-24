using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace miniTC.Model
{
    public class Modeldlapliku
    {
        
        private int plik1;
        public Modeldlapliku()
        {

        }

        public Modeldlapliku(string sciezkapliku, int plik2)
        {
            sciezkadopliku = sciezkapliku;

            plik1 = plik2;
        }

        private string sciezkadopliku;
        public string Sciezkadopliku
        {
            get
            {
                return sciezkadopliku;
            }
            set
            {
                sciezkadopliku = value;
            }
        }

        

        public override string ToString()
        {
            if (plik1 == 0)
            {
                return "[D]" + sciezkadopliku.Substring(sciezkadopliku.LastIndexOf(@"\") + 1);
            }        
            
            else
            {
                return "..";
            }
                
        }
    }
}
