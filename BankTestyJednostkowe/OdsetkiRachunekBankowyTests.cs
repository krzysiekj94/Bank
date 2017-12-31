using System;
using Bank;
using Bank.Mediator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class OdsetkiRachunekBankowyTests
    {
        private OdsetkiMale odsetkiMale;
        private OdsetkiSrednie odsetkiSrednie;
        private OdsetkiDuze odsetkiDuze;
        private Rachunek rachunek;
        private long saldoRachunek;

        void WczytajDane()
        {
            saldoRachunek = 10000;

            rachunek = new Rachunek();
            odsetkiMale = new OdsetkiMale();
            odsetkiDuze = new OdsetkiDuze();
            odsetkiSrednie = new OdsetkiSrednie();

            odsetkiMale.Oblicz();
            odsetkiSrednie.Oblicz();

            rachunek.Saldo = saldoRachunek;
            odsetkiDuze.ProduktBankowy = rachunek;
            odsetkiDuze.Oblicz();
        }

        [TestMethod]
        public void jesliOdsetkiDuzeNullemZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(odsetkiDuze);
        }

        [TestMethod]
        public void jesliOdsetkiMaleJestNullemZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(odsetkiMale);
        }

        [TestMethod]
        public void jesliOdsetkiSrednieJestNullemZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(odsetkiSrednie);
        }

        [TestMethod]
        public void wartoscOdsetkiDuzeRownaSaldoPrzez10()
        {
            WczytajDane();
            Assert.IsTrue( ( odsetkiDuze.Wartosc ) == ( saldoRachunek/10 ) );
        }

        [TestMethod]
        public void wartoscOdsetkiMaleRowna1()
        {
            WczytajDane();
            Assert.IsTrue( odsetkiMale.Wartosc == 1 );
        }

        [TestMethod]
        public void wartoscOdsetkiSrednieRowna1()
        {
            WczytajDane();
            Assert.IsTrue( odsetkiSrednie.Wartosc == 5 );
        }
    }
}
