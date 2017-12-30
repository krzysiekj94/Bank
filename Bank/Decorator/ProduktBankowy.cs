using System;
using System.Collections.Generic;

namespace Bank
{
    public abstract class ProduktBankowy
    {
        protected int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected Osoba _wlasciciel;

        public Osoba Wlasciciel
        {
            get { return _wlasciciel; }
            set { _wlasciciel = value; }
        }

        protected IOdsetki _odsetki;

        public IOdsetki Odsetki
        {
            get { return _odsetki; }
            set { _odsetki = value; }
        }

        private long _saldo;

        public long Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        protected IList<Operacja> _historiaOperacji;

        public IList<Operacja> HistoriaOperacji
        {
            get { return _historiaOperacji; }
            set { _historiaOperacji = value; }
        }

        public abstract void WykonajOperacje(Operacja operacja);
    }
}
