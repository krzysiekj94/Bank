using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.RaportVisitor;
using Bank;
using Bank.Mediator;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class SumaSaldTests
    {
        SumaSald raportSumaSald;
        RachunekDebetowy rachunekDebetowy;
        Lokata lokata;
        Kredyt kredyt;

        long kredytSaldo;
        long lokataSaldo;
        long rachunekDebetowySaldo;

        void WczytajDaneTestowe()
        {
            kredytSaldo = 250;
            lokataSaldo = 12000;
            rachunekDebetowySaldo = 1300;

            raportSumaSald = new SumaSald();
            kredyt = new KredytObj();
            lokata = new Lokata();
            kredyt.Saldo = kredytSaldo;
            lokata.Saldo = lokataSaldo;

            rachunekDebetowy = new RachunekDebetowy(new Rachunek());
            rachunekDebetowy.Saldo = rachunekDebetowySaldo;

        }

        [TestMethod]
        public void SumaSaldRownaSumieDanychTestowych()
        {
            WczytajDaneTestowe();
            long SumaSaldStale = kredytSaldo + lokataSaldo + rachunekDebetowySaldo;
            long SumaSaldVisitor = 0;

            raportSumaSald.Visit(kredyt);
            raportSumaSald.Visit(lokata);
            raportSumaSald.Visit(rachunekDebetowy);
            SumaSaldVisitor = raportSumaSald.Calculate( new BankType( "test", new KIR() ));

            Assert.IsTrue(SumaSaldStale == SumaSaldVisitor );
        }

        [TestMethod]
        public void SumaSaldProduktowBankowychWiekszaOdZera()
        {
            WczytajDaneTestowe();
            raportSumaSald.Visit(kredyt);
            raportSumaSald.Visit(lokata);
            raportSumaSald.Visit(rachunekDebetowy);
            long SumaSaldVisitor = raportSumaSald.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaSaldVisitor > 0);
        }

        [TestMethod]
        public void SumaSaldRownaSalduKredytuPoJegoOdwiedzeniu()
        {
            WczytajDaneTestowe();
            raportSumaSald.Visit(kredyt);
            long SumaSaldVisitor = raportSumaSald.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaSaldVisitor == kredytSaldo );
        }

        [TestMethod]
        public void SumaSaldRownaSalduLokatyPoJejOdwiedzeniu()
        {
            WczytajDaneTestowe();
            raportSumaSald.Visit(lokata);
            long SumaSaldVisitor = raportSumaSald.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaSaldVisitor == lokataSaldo);
        }


        [TestMethod]
        public void SumaSaldRownaSalduRachunkuDebetowegoPoJegoOdwiedzeniu()
        {
            WczytajDaneTestowe();
            raportSumaSald.Visit(rachunekDebetowy);
            long SumaSaldVisitor = raportSumaSald.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaSaldVisitor == rachunekDebetowySaldo);
        }
    }
}
