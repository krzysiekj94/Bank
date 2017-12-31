using System;
using Bank;
using Bank.Mediator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class RachunekTests
    {
        private Rachunek rachunek;
        private Klient klient;
        private BankType bank;
        long kwotaWplaty;

        void WczytajDaneTestowe()
        {
            kwotaWplaty = 2000;
            bank = new BankType("Bank Testowy", new KIR());
            klient = new Klient("12345678909", "Krzysiek", "Nowak");
            rachunek = new Rachunek();
            bank.WykonajOperacje(new OtworzProduktBankowy(rachunek, klient, bank));
            bank.WykonajOperacje(new Wplata(rachunek,kwotaWplaty));
        }

        [TestMethod]
        public void DataZalozeniaRachunkuWczesniejNizDataZamkniecia()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( rachunek.DataZalozenia > rachunek.DataZamkniecia );
        }

        [TestMethod]
        public void ImieWlascielaRachunkuJestNiepuste()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( klient.Imie.Length > 0 );
        }

        [TestMethod]
        public void NazwiskoWlascicielaRachunkuJestNiepuste()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( klient.Nazwisko.Length > 0 );
        }

        [TestMethod]
        public void IdRachunkuJestWiekszeLubRowneZero()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( rachunek.Id >= 0 );
        }

        [TestMethod]
        public void NaRachunkuJestKwotaWplaty()
        {
            WczytajDaneTestowe();
            Assert.IsTrue(rachunek.Saldo == kwotaWplaty);
        }
    }
}
