using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class OdsetkiRachunekBankowyTests
    {
        private OdsetkiRachunekBankowy mechanizmOdsetkowy;
        private Rachunek rachunek;

        void WczytajDane()
        {
            rachunek = new Rachunek()
            {
                Id = 2,
                Saldo = 1000,
                DataZalozenia = new DateTime(2014, 2, 5),
                DataZamkniecia = DateTime.Now
            };

            mechanizmOdsetkowy = new OdsetkiRachunekBankowy();
        }

        [TestMethod]
        public void jesliProduktBankowyJestNullemZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(rachunek);
        }
    }
}
