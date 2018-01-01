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

        void WczytajDaneTestowe()
        {
            bank = new BankType("Bank Testowy", new KIR());
            klient = new Klient("12345678909", "Krzysiek", "Nowak");
            rachunek = new Rachunek();
            rachunek.Wlasciciel = klient;
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
            Assert.IsTrue( rachunek.Wlasciciel.Imie.Length > 0 );
        }

        [TestMethod]
        public void NazwiskoWlascicielaRachunkuJestNiepuste()
        {
            WczytajDaneTestowe();
            Assert.IsTrue(rachunek.Wlasciciel.Nazwisko.Length > 0 );
        }

        [TestMethod]
        public void IdRachunkuJestWiekszeLubRowneZero()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( rachunek.Id >= 0 );
        }

        [TestMethod]
        public void PoczatkoweKontoRachukuRowne0()
        {
            WczytajDaneTestowe();
            Assert.IsTrue(rachunek.Saldo == 0);
        }

        [TestMethod]
        public void DlugoscPeseluRowna11()
        {
            WczytajDaneTestowe();
            Assert.IsTrue(rachunek.Wlasciciel.Pesel.Length == 11);
        }
    }
}
