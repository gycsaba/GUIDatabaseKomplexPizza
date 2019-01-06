using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class SzolgaltatasokUresTablaException : Exception
    {
        public SzolgaltatasokUresTablaException()
            :base()
        {
        }
        public SzolgaltatasokUresTablaException(string uzenet, string tableName)
            : base(uzenet + "\n" + tableName + " tábla üres.")
        {
        }
    }
}
