using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231204_fogadooraa
{
    class Orak
    {
        public string datum, idopont, tanulo, osztaly;
        public Orak(string egysor)
        {
            string[] darabok = egysor.Split(';');
            datum = darabok[0];
            idopont = darabok[1];
            tanulo = darabok[2];
            osztaly = darabok[3];
        }
    }
}
