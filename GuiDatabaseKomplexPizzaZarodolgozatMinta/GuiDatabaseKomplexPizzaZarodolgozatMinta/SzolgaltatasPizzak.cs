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
        public Pizza getPizza(int pizzaAzonosito)
        {
            try
            {
                Pizza p = adattarPizzak.keresPizza(pizzaAzonosito);
                return p;
            }
            catch(AdattarListabanKeresettElemNemTalalhatoException ex)
            {
                throw new Exception(ex.Message+ "\nSzolgaltatlas pizzak: getPizza(int azonosito)");
            }
        }

        public void modositPizzat(Pizza modositandoPizza, Pizza ujPizza)
        {
            try
            {
                if (modositandoPizza.getAzon() != ujPizza.getAzon())
                    throw new SzolgaltatasModositandokAzonositojaNemEgyezikException(
                        "Módosítandó pizza azonositó:" + modositandoPizza.getAzon() +
                        "\nÚj pizza azonosító" + ujPizza.getAzon() +
                        "\nA két azonosító nem egyezik, így a módosítandót nem lehet újra pizzára lecserélni"
                        );
                Pizza p = adattarPizzak.keresPizza(modositandoPizza.getAzon());
                adattarPizzak.modositPizza(ujPizza, modositandoPizza.getAzon());
            }
            catch (AdattarListabanKeresettElemNemTalalhatoException ex)
            {
                throw new Exception(
                    "Módosítandó pizza: " + modositandoPizza.ToString() +
                    "adatok között nem található így módosítani nem lehet");
            }
        }
    }
}
