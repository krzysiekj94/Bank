using System;

namespace Bank
{
    public class Wyplata : Operacja
    {
        public DateTime Czas { get; set; }
        public string Opis { get; set; }
        private long _kwota { get; set; }
        ProduktBankowy _produktBankowy;

        public Wyplata(ProduktBankowy produktBankowy, long kwota)
        {
            _produktBankowy = produktBankowy ??
                throw new ArgumentNullException(nameof(produktBankowy));
            if (kwota < 0)
            {
                throw new InvalidOperationException("Nie mozna wplacic ujemnej kwoty.");
            }
            _kwota = kwota;
        }

        public override void Wykonaj()
        {
            Czas = DateTime.Now;
            _produktBankowy.Saldo -= _kwota;
            _produktBankowy.HistoriaOperacji.Add(this);
        }

        public override string ToString()
        {
            return $"Wyplata: {_kwota}";
        }
    }
}
