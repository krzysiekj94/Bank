using System;
using Bank;
using Bank.Mediator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class WplataTests
    {
        private BankType bank;
        private Klient klient;
        private Rachunek rachunek;
        private long kwotaWplaty;

        public void WczytajDane()
        {
            kwotaWplaty = 0;
            bank = new BankType("Testowy Bank", new KIR());
            klient = new Klient("12345678987", "Krzysztof", "Nowak");
            rachunek = new Rachunek();
            bank.WykonajOperacje(new OtworzProduktBankowy(rachunek, klient, bank));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WplataUjemnejKwotyPowinnaDacAsercje()
        {
            WczytajDane();
            kwotaWplaty = -1000;

            Wplata wplata = new Wplata(rachunek, kwotaWplaty);            
            bank.WykonajOperacje(wplata);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WplataNaNieistniejacyRachunekPowinienDacAsercje()
        {
            WczytajDane();
            kwotaWplaty = 1000;

            Rachunek produktBankowy = null;
            Wplata wplata = new Wplata(produktBankowy, kwotaWplaty);
        }

        [TestMethod]
        public void WplataWartosciDodatniejPowinnaZakonczycSieSukcesem()
        {
            WczytajDane();
            kwotaWplaty = 20000;
            Wplata wplata = new Wplata(rachunek, kwotaWplaty);
            bank.WykonajOperacje( wplata );
        }
    }
}
