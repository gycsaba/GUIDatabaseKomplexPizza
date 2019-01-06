using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectToMysqlDatabase;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class AdattarPizzak
    {
        private List<Pizza> pizzak;

        public AdattarPizzak()
        {
            pizzak = new List<Pizza>();
        }

        public void adatokFeltoltese()
        {
            try
            {
                beolvasPizzakat();
            }
            catch (Exception e)
            {
                throw new AdattarAdatbazisTablaBeolvasasException(e.Message);
            }
        }

        private void beolvasPizzakat()
        {
            Adatbazis a = new Adatbazis();
            MySQLDatabaseInterface mdi = new MySQLDatabaseInterface();
            mdi = a.kapcsolodas();
            if (mdi.open())
            {
                string query = "SELECT * FROM ppizza";
                DataTable pizzadt = new DataTable();
                pizzadt = mdi.getToDataTable(query);
                feltoltPizzaListat(pizzadt);
                mdi.close();
            }
            else
                throw new Exception("Pizza adatbázis megnyitása nem sikerült");
        }

        private void feltoltPizzaListat(DataTable pizzadt)
        {
            foreach (DataRow row in pizzadt.Rows)
            {
                int azon = Convert.ToInt32(row[0]);
                string nev = row[1].ToString();
                int ar = Convert.ToInt32(row[2]);
                Pizza p = new Pizza(azon, nev, ar);
                pizzak.Add(p);
            }
        }

        public List<Pizza> getPizzak()
        {
            return pizzak;
        }
        public DataTable getPizzaDTFromList()
        {
            DataTable pizzaDT = new DataTable();
            pizzaDT.Columns.Add("azon", typeof(int));
            pizzaDT.Columns.Add("nev", typeof(string));
            pizzaDT.Columns.Add("ar", typeof(int));
            foreach (Pizza p in pizzak)
            {
                pizzaDT.Rows.Add(p.getAzon(), p.getNev(), p.getAr());
            }
            return pizzaDT;
        }
    }
}
