using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class Pizza
    {
        private int azon;
        private string nev;
        private int ar;
        /// <values>adott pizza mely tételekben szerepel</values>
        private List<Tetel> tetelek;
        public Pizza(int azon, string nev, int ar)
        {
            this.ar = ar;
            this.nev = nev;
            this.ar = ar;
            tetelek = new List<Tetel>();
        }
    }
}
