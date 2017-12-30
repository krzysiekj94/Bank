using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class RaportFactoryTests
    {
        private RaportTekstowyFactory raportTekstowyFactory;
        private Lokata lokata;
        private Pracownik pracownik;

        void PrzygotujDane()
        {
            raportTekstowyFactory = new RaportTekstowyFactory();
            pracownik = new Pracownik()
            {
                Id = 23,
                Pesel = "13423423423",
                Imie = "Krzysztof",
                Nazwisko = "Nowak"
            };

            lokata = new Lokata()
            {
                Id = 4,
                Saldo = 1000,
                Wlasciciel = pracownik,
                DataZalozenia = new DateTime(1994, 08, 24)
            };
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GenerujRaport()
        {
            PrzygotujDane();
            raportTekstowyFactory.UtworzRaport(lokata);
        }
    }
}
