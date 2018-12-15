using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class PizzaFutar
    {

        private string cegnev;
        private Adattar adattar;
        public PizzaFutar(string cegnev)
        {
            this.cegnev = cegnev;
            this.adattar = new Adattar();
            adattar.adatokFeltoltese();
        }
        public string getCegnev()
        {
            return cegnev;
        }
    }
}
