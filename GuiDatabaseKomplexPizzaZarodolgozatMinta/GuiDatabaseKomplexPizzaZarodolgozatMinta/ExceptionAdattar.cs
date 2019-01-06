using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class AdattarAdatbazisTablaBeolvasasException :Exception
    {
        public AdattarAdatbazisTablaBeolvasasException(string message)
            : base(message)
        { }
    }
    class AdattarListaElemNemTalalhatoException : Exception
    {
        public AdattarListaElemNemTalalhatoException(string message)
            : base(message)
        { }
    }
}
