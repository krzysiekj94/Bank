using System;
using Bank;
using Bank.RaportVisitor;
using Bank.Mediator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class RaportTests
    {
        private SumaSald raportVisitor1;
        private Rachunek rachunek;
        private Pracownik pracownik;
        private BankType bank;
        private Wyplata wyplata;
        long kwotaWyplaty;

        void PrzygotujDane()
        {
            kwotaWyplaty = 10000;
            bank = new BankType("BankTest", new KIR());
            rachunek = new Rachunek();
            wyplata = new Wyplata(rachunek, kwotaWyplaty);
            bank.WykonajOperacje(wyplata);
            raportVisitor1 = new SumaSald();
        }

        [TestMethod]
        public void SumaWyplatRownaKwocieWyplaty()
        {
            PrzygotujDane();
            Assert.IsTrue(raportVisitor1.Calculate(bank) == kwotaWyplaty);
        }

        [TestMethod]
        public void SumaSaldNieJestNullem()
        {
            PrzygotujDane();
            Assert.IsNotNull(raportVisitor1);
        }

        [TestMethod]
        public void SumaWyplatPowiekszonaO200()
        {
            PrzygotujDane();
            bank.WykonajOperacje(new Wyplata(rachunek,200));
            raportVisitor1.Calculate(bank);
            Assert.IsTrue((raportVisitor1.Calculate(bank) + 200) == ( kwotaWyplaty + 200 ));
        }
    }
}
