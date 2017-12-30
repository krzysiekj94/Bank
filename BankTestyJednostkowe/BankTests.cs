using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bank.RaportVisitor;
using Bank.Mediator;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class BankTests
    {
        private BankType bank;
        private Osoba osoba;
        private Operacja operacjaDodajKlienta;
        private Operacja operacjaOtworzProduktBankowy;
        private Operacja operacjaGenerowaniaRaportu;
        private ProduktBankowy produktBankowy;
        private IRaportVisitor raportFactory;
        private KIR kirBank;

        void WczytajDaneTestowe()
        {
            kirBank = new KIR();

            bank = new BankType("Testowy Bank", kirBank);

            osoba = new Klient("11182400431", "Dawid", "Nowak");

            produktBankowy = new KredytObj();


               
            /*    
                Id = 2,
                Wlasciciel = osoba,
                Saldo = 23132,
                DataZalozenia = new DateTime(2004, 12, 2),
                DataZamkniecia = new DateTime(1970, 1, 1),
                HistoriaOperacji = new List<IOperacja>()
            };
            */

            raportFactory = new RaportTekstowyFactory();

            operacjaDodajKlienta = new DodajKlienta()
            {
                Id = 3,
                Czas = new DateTime(1994,12,15),
                Opis = "Opis1",
                Bank = bank,
                Klient = osoba
            };

            operacjaOtworzProduktBankowy = new OtworzProduktBankowy()
            {
                Id = 2,
                Bank = bank,
                Czas = DateTime.Now,
                Opis = "Nowy produkt bankowy",
                Wlasciciel = osoba,
                ProduktBankowy = produktBankowy,
            };

            operacjaGenerowaniaRaportu = new GenerujRaportDlaProduktuBankowego()
            {
                Id = 2,
                Bank = bank,
                Czas = DateTime.Now,
                Opis = "Generowanie raportu dla produktu bankowego",
                ProduktBankowy = produktBankowy,
                RaportFactory = raportFactory
            };
        }

        [TestMethod]
        public void PustyProduktBankowyPowinienZwrocicAsercje()
        {
            WczytajDaneTestowe();
            produktBankowy = null;

            Assert.IsNull(produktBankowy);
        }

       [TestMethod]
       public void CzyHistoriaOperacjiNieJestNullem()
       {
            WczytajDaneTestowe();
            Assert.IsNotNull(bank.HistoriaOperacji);
       }

        [TestMethod]
        public void CzyListaProduktowBankowychNieJestPusta()
        {
            WczytajDaneTestowe();
            Assert.IsNotNull(bank.ProduktyBankowe);
        }

        [TestMethod]
        public void CzyPoDodaniuNowegoKlientaListaNiepusta()
        {
            WczytajDaneTestowe();
            bank.WykonajOperacje(operacjaDodajKlienta);

            Assert.IsTrue(bank.Klienci.Count > 0);
        }

        [TestMethod]
        public void CzyPoDodaniuNowegoProduktuListaProduktowBankuNiepusta()
        {
            WczytajDaneTestowe();
            bank.WykonajOperacje(operacjaOtworzProduktBankowy);
            Assert.IsTrue(bank.ProduktyBankowe.Count > 0);
        }

        [TestMethod]
        public void CzyPoDodaniuNowegoProduktuDoKlientaMaOnProdukt()
        {
            WczytajDaneTestowe();
            bank.WykonajOperacje(operacjaOtworzProduktBankowy);
            Assert.IsTrue(bank.PobierzProduktyBankoweKlienta(osoba).Count > 0);
        }

        [TestMethod]
        public void CzyListaOperacjiNiepustaPoWykonaniuOperacji()
        {
            WczytajDaneTestowe();
            bank.WykonajOperacje(operacjaDodajKlienta);
            Assert.IsTrue(bank.HistoriaOperacji.Count > 0);
        }
        [TestMethod]
        public void CzyPoWygenerowaniuRaportuListaTaJestNiepusta()
        {
            WczytajDaneTestowe();
            bank.WykonajOperacje(operacjaGenerowaniaRaportu);
            Assert.IsTrue(bank.Raporty.Count > 0);
        }
    }
}