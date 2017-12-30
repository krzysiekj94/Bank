using System;

namespace Bank
{
    public class PrzelewOut : Operacja
    {
        public DateTime Czas { get; set; }
        public string Opis { get; set; }
        private long _kwota { get; set; }
        public long Kwota
        {
            get
            {
                return _kwota;
            }
        }
        private ProduktBankowy _z;
        public ProduktBankowy Z
        {
            get
            {
                return _z;
            }
        }
        private ProduktBankowy _na;
        public ProduktBankowy Na
        {
            get
            {
                return _na;
            }
        }

        public PrzelewOut(ProduktBankowy z, ProduktBankowy na, long kwota)
        {
            _z = z ??
                throw new ArgumentNullException(nameof(z));
            _na = na ??
                throw new ArgumentNullException(nameof(na));

            if (kwota < 0)
            {
                throw new InvalidOperationException("Nie mozna przelać ujemnej kwoty.");
            }
            _kwota = kwota;
        }

        public override void Wykonaj()
        {
            Czas = DateTime.Now;

            _na.Saldo += _kwota;
            _na.HistoriaOperacji.Add(this);
        }

        public override string ToString()
        {
            return $"Przelew na: {_na.Id}, kwota: {_kwota}";
        }
    }
}