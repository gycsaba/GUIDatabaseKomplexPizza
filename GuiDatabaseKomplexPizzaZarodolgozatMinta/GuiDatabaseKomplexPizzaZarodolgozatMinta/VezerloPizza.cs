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
                return dtPizza;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nVezérlő:getPizzakTable()+szolgaltatasPizzak.getPizzakTabla())");
            }
        }
    }
}
