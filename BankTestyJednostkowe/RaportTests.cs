using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class RaportTests
    {
        private RaportTekstowy raportTekstowy;

        void WczytajDane()
        {
            raportTekstowy = new RaportTekstowy
            {
                IdRaport = 2,
                DataRaportu = DateTime.Now,
                Opis = "raport1"
            };
        }

        [TestMethod]
        public void IdRaportuWiekszeLubRowne0()
        {
            WczytajDane();
            Assert.IsTrue(raportTekstowy.IdRaport >= 0);
        }

        [TestMethod]
        public void DataRaportuJestRoznaOdNulla()
        {
            WczytajDane();
            Assert.IsNotNull(raportTekstowy.DataRaportu);
        }

        [TestMethod]
        public void OpisRaportuNieJestPusty()
        {
            WczytajDane();
            Assert.IsTrue(raportTekstowy.ToString().Length > 0);
        }
    }
}
