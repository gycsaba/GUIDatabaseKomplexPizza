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
        public PizzaFutar(string cegnev)
        {
            this.cegnev = cegnev;
        }
        public string getCegnev()
        {
            return cegnev;
        }
    }
}
