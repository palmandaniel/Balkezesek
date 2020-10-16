using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    class Jatekos
    {
        public string Nev { get; set; }
        public string Elso { get; set; }
        public string Utolso { get; set; }
        public int Suly { get; set; }
        public int Magassag { get; set; }

        public Jatekos(string szoveg)
        {
            string[] adat = szoveg.Split(';');
            Nev = adat[0];
            Elso = adat[1];
            Utolso = adat[2];
            Suly = int.Parse(adat[3]);
            Magassag = int.Parse(adat[4]);
        }

        
    }
}
