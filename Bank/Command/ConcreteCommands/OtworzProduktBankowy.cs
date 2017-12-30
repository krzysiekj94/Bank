using System;

namespace Bank
{
    public class OtworzProduktBankowy : Operacja
    {
        public DateTime Czas { get; set; }
        public string Opis { get; set; }

        private ProduktBankowy _produktBankowy;
        private Osoba _wlasciciel;
        private BankType _bank;

        public OtworzProduktBankowy(ProduktBankowy produktBankowy,
            Osoba wlasciciel, BankType bank)
        {
            _produktBankowy = produktBankowy ?? 
                throw new ArgumentNullException(nameof(produktBankowy));
            _wlasciciel = wlasciciel ??
                throw new ArgumentNullException(nameof(wlasciciel));
            _bank = bank ??
                throw new ArgumentNullException(nameof(bank));
        }

        public override void Wykonaj()
        {
            _produktBankowy.Wlasciciel = _wlasciciel;
            _bank.ProduktyBankowe.Add(_produktBankowy);
        }
    }
}
