using System;

namespace Bank
{
    public class DodajKlienta : Operacja
    {
        public DateTime Czas { get; set; }
        public string Opis { get; set; }

        private Klient _klient = null;
        private BankType _bank = null;

        public DodajKlienta(Klient klient, BankType bank)
        {
            _klient = klient;
            _bank = bank;
        }

        public override void Wykonaj()
        {
            if (_klient.Pesel.Length != 11)
            {
                throw new ArgumentException("Niepoprawna ilość znaków w numerze pesel.");
            }
            _bank.Klienci.Add(_klient);
        }
    }
}
