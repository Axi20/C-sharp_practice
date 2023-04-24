using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    //Számok segédosztály - azért kell, hogy el tudjuk tárolni melyik számot hányszor húzták ki.
    internal class Szamok
    {
        public int szam;
        public int darab;

        public Szamok(int szam, int darab)
        {
            this.szam = szam;
            this.darab = darab;
        }
    }
}
