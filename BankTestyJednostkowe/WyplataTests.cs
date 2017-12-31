using System;
using Bank;
using Bank.Mediator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class WyplataTests
    {
        private BankType bank;
        private Klient klient;
        private Rachunek rachunek;
        private long kwotaWyplaty;

        public void ExampleData1()
        {
            kwotaWyplaty = 1000;
            bank = new BankType("Testowy bank", new KIR());
            klient = new Klient("12345643212", "Jan", "Borowiak");
            rachunek = new Rachunek();

            bank.WykonajOperacje(new OtworzProduktBankowy(rachunek, klient, bank));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WyplataUjemnejKwotyPowinnaZwrocicAsercje()
        {
            ExampleData1();
            kwotaWyplaty = -10000;

            Wyplata wyplata = new Wyplata(rachunek, kwotaWyplaty);
            bank.WykonajOperacje(wyplata);
        }

        [TestMethod]
        public void WyplataKwotyDodatniejZSaldaNiezerowegoJestPoprawna()
        {
            ExampleData1();
            kwotaWyplaty = 10000;

            Wyplata wyplata = new Wyplata(rachunek, kwotaWyplaty);
            bank.WykonajOperacje(wyplata);
        }

        [TestMethod]
        public void WyplataKwotyZSalda0PowinnaZwrocicAsercje()
        {
            ExampleData1();
            kwotaWyplaty = 0;

            Wyplata wyplata = new Wyplata(rachunek, kwotaWyplaty);
            bank.WykonajOperacje(wyplata);
        }
    }
}
