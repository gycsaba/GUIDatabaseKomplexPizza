using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    partial class Vezerlo
    { 
        public  DataTable getPizzakTabla()
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
                throw new Exception(ex.Message + "\nVezérlő:getPizzakTable()+szolgaltatasPizzak.getPizzakTabla())");
            }
        }     
    }
}
