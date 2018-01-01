using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using Bank.Mediator;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class DodanieKlientaTests
    {
        private BankType bank;
        private Klient klient;
        private DodajKlienta dodajKlienta;
       
        void WczytajDaneTestowe()
        {
            bank = new BankType("test", new KIR());
            klient = new Klient("12345678909", "Kazimierz", "Nowak");
            dodajKlienta = new DodajKlienta(klient, bank);
        }

        [TestMethod]
        public void DodanieKlientaOPeseluDlugosci11NiePowinnoZglaszacWyjatku()
        {
            WczytajDaneTestowe();
            bank.WykonajOperacje(dodajKlienta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DodanieKlientaOPeseluDlugosci3PowinnoZglosicWyjatek()
        {
            WczytajDaneTestowe();

            klient = new Klient("232", "Kazimierz", "Nowak");
            dodajKlienta = new DodajKlienta(klient, bank);
            bank.WykonajOperacje(dodajKlienta);
        }

        [TestMethod]
        public void DodanieKlientaPowinnoZwiekszycLiczbeElementowNaLiscieKlientowOJeden()
        {
            WczytajDaneTestowe();

            long liczbaElementowPrzed = bank.Klienci.Count;
            long liczbaElementowPo = 0;

            bank.WykonajOperacje(dodajKlienta);
            liczbaElementowPo = bank.Klienci.Count;

            Assert.IsTrue(liczbaElementowPrzed + 1 == liczbaElementowPo);
        }
    }
}
