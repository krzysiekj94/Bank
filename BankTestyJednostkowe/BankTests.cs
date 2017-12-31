using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.Mediator;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class BankTests
    {
        private BankType bank1;
        private BankType bank2;
        private BankType bank3;
        private Klient osoba1;
        private Klient osoba2;
        private Operacja operacjaDodajKlienta1;
        private Operacja operacjaDodajKlienta2;
        private Operacja operacjaOtworzProduktBankowyOsoba1;
        private Operacja operacjaOtworzProduktBankowyOsoba2;
        private Operacja operacjaPrzelew;
        private ProduktBankowy produktBankowyOsoba1;
        private ProduktBankowy produktBankowyOsoba2;
        private KIR kirBank;

        void WczytajDaneTestowe()
        {
            kirBank = new KIR();

            bank1 = new BankType("Testowy Bank", kirBank);
            bank2 = new BankType("Test2", kirBank);
            bank3 = new BankType("Test3", kirBank);

            kirBank.AddBank(bank1);
            kirBank.AddBank(bank2);
            kirBank.AddBank(bank3);

            osoba1 = new Klient( "11182400431", "Dawid", "Nowak" );
            osoba2 = new Klient( "94234533412", "Michał", "Szpak" );

            produktBankowyOsoba1 = new KredytObj();
            produktBankowyOsoba2 = new Rachunek();

            operacjaDodajKlienta1 = new DodajKlienta( osoba1, bank1 );
            operacjaDodajKlienta2 = new DodajKlienta( osoba2, bank2 );

            operacjaOtworzProduktBankowyOsoba1 = new OtworzProduktBankowy( produktBankowyOsoba1, osoba1, bank1 );
            operacjaOtworzProduktBankowyOsoba2 = new OtworzProduktBankowy( produktBankowyOsoba2, osoba2, bank2 );

            operacjaPrzelew = new PrzelewOut( produktBankowyOsoba1, produktBankowyOsoba2, 10000 );
        }

      [TestMethod]
      public void CzySaldoWiekszeO10000ZlPoPrzelewie()
      {
            WczytajDaneTestowe();
            long SaldoPoczatkowe = produktBankowyOsoba2.Saldo;
            long SaldoKoncowe = 0;
            operacjaPrzelew.Wykonaj();

            SaldoKoncowe = produktBankowyOsoba2.Saldo;

            Assert.IsTrue(SaldoPoczatkowe + 10000 == SaldoKoncowe);  
      }

       [TestMethod]
       public void CzyHistoriaOperacjiNieJestNullem()
       {
            WczytajDaneTestowe();
            Assert.IsNotNull(bank1.HistoriaOperacji);
       }

        [TestMethod]
        public void CzyListaProduktowBankowychNieJestPusta()
        {
            WczytajDaneTestowe();
            Assert.IsNotNull(bank1.ProduktyBankowe);
        }

        [TestMethod]
        public void CzyPoDodaniuNowegoKlientaDoBanku1ListaNiepusta()
        {
            WczytajDaneTestowe();
            bank1.WykonajOperacje(operacjaDodajKlienta1);

            Assert.IsTrue( bank1.Klienci.Count > 0 );
        }

        [TestMethod]
        public void CzyListaBanku1NiepustaPoDodaniaProduktuBankowego()
        {
            WczytajDaneTestowe();
            bank1.WykonajOperacje(operacjaOtworzProduktBankowyOsoba1);
            Assert.IsTrue(bank1.ProduktyBankowe.Count > 0);
        }

        [TestMethod]
        public void CzyPoDodaniuNowegoProduktuDoKlienta1MaOnProdukt()
        {
            WczytajDaneTestowe();
            bank1.WykonajOperacje(operacjaOtworzProduktBankowyOsoba1);
            Assert.IsTrue(bank1.PobierzProduktyBankoweKlienta(osoba1).Count > 0);
        }

        [TestMethod]
        public void CzyListaOperacjiBanku2NiepustaPoWykonaniuOperacji()
        {
            WczytajDaneTestowe();
            bank2.WykonajOperacje(operacjaOtworzProduktBankowyOsoba2);
            Assert.IsTrue(bank2.HistoriaOperacji.Count > 0);
        }
    }
}