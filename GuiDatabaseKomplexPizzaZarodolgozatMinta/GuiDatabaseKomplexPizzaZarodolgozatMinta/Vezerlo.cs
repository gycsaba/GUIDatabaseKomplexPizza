using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    class Vezerlo
    {
        private SzolgaltatasPizzak szolgaltatasPizzak;
        private SzolgaltatasVevok szolgaltatasVevok;
        private SzolgaltatasFutarok szolgaltatasFutarok;
        private SzolgaltatasRendelesek szolgaltatasRendelesek;
        private SzolgaltatasTetelek szolgaltatasTetelek;

        public Vezerlo()
        {
            szolgaltatasPizzak=new SzolgaltatasPizzak();
            szolgaltatasVevok = new SzolgaltatasVevok();
            szolgaltatasFutarok=new SzolgaltatasFutarok();
            szolgaltatasRendelesek=new SzolgaltatasRendelesek();
            szolgaltatasTetelek=new SzolgaltatasTetelek();
        }

        internal object getPizzakTabla()
        {
            throw new NotImplementedException();
        }
    }
}
