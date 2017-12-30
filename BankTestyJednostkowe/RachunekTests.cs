using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class RachunekTests
    {
        private Rachunek rachunek;
        private Klient klient;
        private Wyplata wyplata;

        void WczytajDaneTestowe()
        {
            rachunek = new Rachunek();
            klient = new Klient();
            wyplata = new Wyplata();

            rachunek.Id = 12;
            rachunek.Saldo = 2000;
            rachunek.MaxDebet = -230;
            rachunek.DataZalozenia = new DateTime( 1994, 08, 24 );
            rachunek.DataZamkniecia = new DateTime( 2000, 02, 12 );

            klient.Imie = "Krzysztof";
            klient.Nazwisko = "Jerzyński";

            wyplata.Id = 1;
            wyplata.Kwota = 12;
            wyplata.Czas = new DateTime(2017, 11, 24, 15, 16, 54, 12);
        }

        [TestMethod]
        public void StanRachunkuNieMniejszyOdMaxDebet()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( rachunek.Saldo >= rachunek.MaxDebet );
        }

        [TestMethod]
        public void DataZalozeniaRachunkuWczesniejNizDataZamkniecia()
        {
            WczytajDaneTestowe();
            Assert.IsTrue( rachunek.DataZalozenia <= rachunek.DataZamkniecia );
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
        [ExpectedException(typeof(System.NullReferenceException))]
        public void OperacjaNaRachunkuZakonczonaPowodzeniem()
        {
            WczytajDaneTestowe();
            rachunek.WykonajOperacje( wyplata );
        }
    }
}
