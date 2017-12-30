using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Kredyt : ProduktBankowy
    {
        protected int _iloscSplat;

        public int IloscSplat
        {
            get { return _iloscSplat; }
            set { _iloscSplat = value; }
        }

        private DateTime _terminSplat;

        public DateTime TerminSplat
        {
            get { return _terminSplat; }
            set { _terminSplat = value; }
        }
    }
}
