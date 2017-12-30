using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class OdsetkiTests
    {
        private OdsetkiDuze odsetkiDuze;
        private IProduktBankowy produktBankowyOdsetkiMale;
        private IProduktBankowy produktBankowyOdsetkiSrednie;
        private IProduktBankowy produktBankowyOdsetkiDuze;
        private IOsoba pracownik;
        private BankType bank;

        void WczytajDane()
        {
            bank = new BankType("Testowy bank");

            pracownik = new Pracownik()
            {
                Id = 1,
                Imie = "Krzysztof",
                Nazwisko = "Nowak",
                Pesel = "12345678909",
                Plec = "M",
                DataPoczPracy = new DateTime(2016, 02, 15),
                DataKonPracy = new DateTime(1900, 01, 01),
                DataUrodzenia = new DateTime(1994, 08, 24)
            };

            produktBankowyOdsetkiMale = new Rachunek()
            {
                Id = 2,
                Saldo = 1000,
                DataZalozenia = new DateTime(2014, 2, 5),
                DataZamkniecia = DateTime.Now,
                HistoriaOperacji = new List<IOperacja>(),
                Wlasciciel = pracownik,
                Odsetki = new OdsetkiMale()
            };

            produktBankowyOdsetkiSrednie = new Kredyt()
            {
                Id = 2,
                Saldo = 1000,
                DataZalozenia = new DateTime(2014, 2, 5),
                DataZamkniecia = DateTime.Now,
                HistoriaOperacji = new List<IOperacja>(),
                Wlasciciel = pracownik,
                Odsetki = new OdsetkiSrednie(),
            };

            odsetkiDuze = new OdsetkiDuze();
            produktBankowyOdsetkiDuze = new Lokata()
            {
                Id = 2,
                Saldo = 1000,
                DataZalozenia = new DateTime(2014, 2, 5),
                DataZamkniecia = DateTime.Now,
                HistoriaOperacji = new List<IOperacja>(),
                Wlasciciel = pracownik,
                Odsetki = odsetkiDuze
            };
        }

        [TestMethod]
        public void JesliProduktBankowyOdsetkiMaleJestNullZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(produktBankowyOdsetkiMale);
        }

        [TestMethod]
        public void JesliProduktBankowyOdsetkiSrednieJestNullZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(produktBankowyOdsetkiSrednie);
        }

        [TestMethod]
        public void JesliProduktBankowyOdsetkiDuzeJestNullZwrocAsercje()
        {
            WczytajDane();
            Assert.IsNotNull(produktBankowyOdsetkiDuze);
        }

        [TestMethod]
        public void JestliOdsetkiMaleZProduktuBankowegoZwrocaWartosc1()
        {
            WczytajDane();
            produktBankowyOdsetkiMale.Odsetki.Oblicz();
            Assert.IsTrue( produktBankowyOdsetkiMale.Odsetki.Wartosc == 1 );
        }

        [TestMethod]
        public void JestliOdsetkiSrednieZProduktuBankowegoZwrocaWartosc5()
        {
            WczytajDane();
            produktBankowyOdsetkiSrednie.Odsetki.Oblicz();
            Assert.IsTrue(produktBankowyOdsetkiSrednie.Odsetki.Wartosc == 5);
        }

        [TestMethod]
        public void JestliOdsetkiDuzeZProduktuBankowegoZwrocaWartoscSaldoPrzez10()
        {
            long odsetkiRachunekBankowy = 0;

            WczytajDane();
            odsetkiDuze.ProduktBankowy = produktBankowyOdsetkiDuze;
            odsetkiRachunekBankowy = produktBankowyOdsetkiDuze.Saldo / 10;
            produktBankowyOdsetkiDuze.Odsetki.Oblicz();

            Assert.IsTrue( produktBankowyOdsetkiDuze.Odsetki.Wartosc == odsetkiRachunekBankowy );
        }
    }
}
