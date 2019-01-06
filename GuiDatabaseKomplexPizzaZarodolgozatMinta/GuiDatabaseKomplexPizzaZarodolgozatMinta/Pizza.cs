using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    public class Pizza
    {
        private int azon;
        private string nev;
        private int ar;
        /// <values>adott pizza mely tételekben szerepel</values>
        private List<Tetel> tetelek;
        public Pizza(int azon, string nev, int ar)
        {
            this.azon = azon;
            this.nev = nev;
            this.ar = ar;
            tetelek = new List<Tetel>();
        }
        public void setAzon(int azon)
        {
            this.azon = azon;
        }
        public void setNev(string nev)
        {
            this.nev = nev;
        }
        public void setAr(int ar)
        {
            this.ar = ar;
        }
        public int getAzon()
        {
            return azon;
        }
        public string getNev()
        {
            return nev;
        }
        public int getAr()
        {
            return ar;
        }

        internal string getSQLUpdate()
        {
            string query =
                "UPDATE ppizza " +
                " SET " +
                " pazon=" + azon +
                ", pnev=\"" + nev + "\"" +
                ", par=" + ar;
            return query;
        }
    }
}
