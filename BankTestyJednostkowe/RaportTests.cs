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
        private BankType bank;
        private Wyplata wyplata;
        long kwotaWyplaty;

        void PrzygotujDane()
        {
            kwotaWyplaty = 1200;
            bank = new BankType("BankTest", new KIR());
            rachunek = new Rachunek();
            wyplata = new Wyplata(rachunek, kwotaWyplaty);
            raportVisitor1 = new SumaSald();
        }

        [TestMethod]
        public void SumaWyplatRownaKwocieWyplaty()
        {
            PrzygotujDane();
            bank.WykonajOperacje(wyplata);
            raportVisitor1.Visit(rachunek);
            Assert.IsTrue( Math.Abs(raportVisitor1.Calculate(bank)) == kwotaWyplaty );
        }

        [TestMethod]
        public void SumaSaldNieJestNullem()
        {
            PrzygotujDane();
            Assert.IsNotNull(raportVisitor1);
        }

        [TestMethod]
        public void SumaWyplatRowna0()
        {
            PrzygotujDane();
            raportVisitor1.Visit(rachunek);
            Assert.IsTrue((raportVisitor1.Calculate(bank)) == 0);
        }
    }
}
