using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class SzolgaltatasPizzak
    {
        private AdattarPizzak adattarPizzak;

        public SzolgaltatasPizzak()
        {
            adattarPizzak = new AdattarPizzak();
        }

        public DataTable getPizzakTabla()
        {
            try
            {
                adattarPizzak.adatokFeltoltese();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nSzolgaltatlas pizzak: getPizzakTable()");
            }
            try
            {
                DataTable dtPizzak=adattarPizzak.getPizzaDTFromList();
                if (dtPizzak.Rows.Count == 0)
                    throw new SzolgaltatasokUresTablaException
                        ("SzolgaltatasokPizzak osztály:adatokFeltoltese() method:","pizzak");
                else
                    return dtPizzak;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + "\nSzolgaltatlas pizzak: getPizzakTable()");
            }
            
        }
    }
}
