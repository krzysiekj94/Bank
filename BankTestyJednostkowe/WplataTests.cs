using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class WplataTests
    {
        private BankType bank;
        private Klient klient;
        private Rachunek rachunek; 

        public void ExampleData1()
        {
            bank = new BankType("UnitTestBank");

            klient = new Klient()
            {
                Id = 0,
                Imie = "A",
                Nazwisko = "B",
                DataUrodzenia = DateTime.Now,
                Pesel = "123213asdad",
                Plec = "m"
            };

            rachunek = new Rachunek()
            {
                Id = 0,
                Wlasciciel = klient,
                DataZalozenia = DateTime.Now - (new TimeSpan(3, 0, 0, 0, 0)),
                DataZamkniecia = DateTime.Now,
                MaxDebet = 0,
                Saldo = 2000
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WplataUjemnejKwotyPowinnaDacAsercje()
        {
            ExampleData1();

            Wplata wplata = new Wplata();
            wplata.ProduktBankowy = rachunek;
            wplata.Kwota = -123;
            
            bank.WykonajOperacje(wplata);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void WplataKwotyNaNieistniejacymRachunkuPowinnaRzucicWyjatek()
        {
            ExampleData1();   
            rachunek = null;

            Wplata wplata = new Wplata();

            wplata.ProduktBankowy = rachunek;
            wplata.Kwota = 1234;

            bank.WykonajOperacje(wplata);
        }

        [TestMethod]
        public void WplataWartosciDodatniejPowinnaZakonczycSieSukcesem()
        {
            ExampleData1();
            Wplata wplata = new Wplata();
            wplata.ProduktBankowy = rachunek;
            wplata.Kwota = 2000;

            bank.WykonajOperacje( wplata );
        }
    }
}
