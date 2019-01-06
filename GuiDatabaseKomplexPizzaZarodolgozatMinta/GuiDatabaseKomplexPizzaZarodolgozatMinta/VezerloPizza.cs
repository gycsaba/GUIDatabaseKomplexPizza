using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    partial class Vezerlo
    {
        public DataTable getPizzakTabla()
        {
            try
            {
                DataTable dtPizza = szolgaltatasPizzak.getPizzakTabla();
                fm.beallitPizzaVezerloketSikeresBetoltesUtan();
                return dtPizza;
            }
            catch (SzolgaltatasokUresTablaException ex)
            {
                fm.beallitPizzaVezerloketUresTablaAllapotba();
                return null;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message + "\nVezérlő:getPizzakTable()");
                return null;
            }
        }
        public void lekerPizzaAdatokatModositashoz(int pizzaAzonosito)
        {
            try
            {
                Pizza p = szolgaltatasPizzak.getPizza(pizzaAzonosito);
                fm.eltarolEsMegjelenitPizzatModositashoz(p);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message + "\nVezérlő:lekerPizzaAdatokatModositashoz()");
            }
        }
        public void modositPizzat(Pizza modositandoPizza, Pizza ujPizza)
        {
            try
            {
                szolgaltatasPizzak.modositPizzat(modositandoPizza, ujPizza);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message + "\nVezérlő:modositPizzat())");
            }
        }
    }
}
