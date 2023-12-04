using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231113_gumis
{
    class Munkak
    {
        public string datum, ora, nev, tell, rendszam;
        public Munkak(string egysor)
        {
            string[] darabok = egysor.Split(';');
            datum = darabok[0];
            ora = darabok[1];
            nev = darabok[2];
            tell = darabok[3];
            rendszam = darabok[4];
        }
        
    }
}
