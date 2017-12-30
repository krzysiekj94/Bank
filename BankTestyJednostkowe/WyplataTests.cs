using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class WyplataTests
    {
        private BankType bank;
        private Klient klient;
        private Rachunek rachunek;
        private Wyplata wplata;
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

            wplata = new Wyplata()
            {
                ProduktBankowy = rachunek,
                Kwota = -123
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WyplataUjemnejKwotyPowinnaZwrocicAsercje()
        {
            ExampleData1();
            bank.WykonajOperacje(wplata) ;
        }

        [TestMethod]
        public void WyplataKwotyDodatniejZSaldaJestPoprawna()
        {
            ExampleData1();

            Wyplata wyplata = new Wyplata();
            wyplata.ProduktBankowy = rachunek;
            wyplata.Kwota = 1000;

            bank.WykonajOperacje(wyplata);
        }
    }
}
