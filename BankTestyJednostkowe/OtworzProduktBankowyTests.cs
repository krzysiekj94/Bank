using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using Bank.Mediator;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class OtworzProduktBankowyTests
    {
        private BankType bank;
        private Klient wlascicielKonta;
        private OtworzProduktBankowy otworzRachunek;
        private ProduktBankowy rachunek;

        void WczytajDaneTestowe()
        {
            bank = new BankType("Testowy Bank", new KIR());
            wlascicielKonta = new Klient("11182400431", "Dawid", "Nowak");

            rachunek = new Rachunek();
            otworzRachunek = new OtworzProduktBankowy(rachunek, wlascicielKonta, bank);
        }

        [TestMethod]
        public void OtwarcieRachunkuPowinnoZwiekszycLiczbeElementowNaLiscieOJeden()
        {
            WczytajDaneTestowe();

            long liczbaElementowPrzed = bank.ProduktyBankowe.Count;
            long liczbaElementowPo = 0;

            bank.WykonajOperacje(otworzRachunek);
            liczbaElementowPo = bank.ProduktyBankowe.Count;

            Assert.IsTrue(liczbaElementowPrzed + 1 == liczbaElementowPo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OtwarcieRachunkuWNieistniejacymBankuPowinnoZwrocicAsercje()
        {
            WczytajDaneTestowe();
            bank = null;
            otworzRachunek = new OtworzProduktBankowy(rachunek, wlascicielKonta, bank);
            bank.WykonajOperacje(otworzRachunek);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OtwarcieRachunkuDlaNiestniejacegoWlascicielaPowinnoZwrocicAsercje()
        {
            WczytajDaneTestowe();
            wlascicielKonta = null;
            otworzRachunek = new OtworzProduktBankowy(rachunek, wlascicielKonta, bank);
            bank.WykonajOperacje(otworzRachunek);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OtwarcieRachunkuNaNieistniejacymKlienciePowinnoZwrocicAsercje()
        {
            WczytajDaneTestowe();
            wlascicielKonta = null;
            otworzRachunek = new OtworzProduktBankowy(rachunek, wlascicielKonta, bank);
            bank.WykonajOperacje(otworzRachunek);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OtwarcieNiezainicjalizowanegoRachunkuPowinnoZwrocicAsercje()
        {
            WczytajDaneTestowe();
            rachunek = null;
            otworzRachunek = new OtworzProduktBankowy(rachunek, wlascicielKonta, bank);
            bank.WykonajOperacje(otworzRachunek);
        }
    }
}
