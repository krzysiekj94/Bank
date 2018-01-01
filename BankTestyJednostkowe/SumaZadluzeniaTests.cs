using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.RaportVisitor;
using Bank;
using Bank.Mediator;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class SumaZadluzeniaTests
    {
        SumaZadluzenia raportSumaZadluzenia;
        RachunekDebetowy rachunekDebetowy;
        Lokata lokata;
        Kredyt kredyt;

        long kredytSaldo;
        long lokataSaldo;
        long rachunekDebetowySaldo;

        void WczytajDaneTestowe()
        {
            kredytSaldo = -5000;
            lokataSaldo = 12000;
            rachunekDebetowySaldo = -2000;

            raportSumaZadluzenia = new SumaZadluzenia();
            kredyt = new KredytObj();
            lokata = new Lokata();

            kredyt.Saldo = kredytSaldo;
            lokata.Saldo = lokataSaldo;

            rachunekDebetowy = new RachunekDebetowy(new Rachunek());
            rachunekDebetowy.Saldo = rachunekDebetowySaldo;

        }

        [TestMethod]
        public void SumaZadluzeniaRownaSumieDanychTestowych()
        {
            WczytajDaneTestowe();

            long SumaZadluzeniaZmienne = kredytSaldo + rachunekDebetowySaldo;
            long SumaZadluzeniaVisitor = 0;
            raportSumaZadluzenia.Visit(kredyt);
            raportSumaZadluzenia.Visit(lokata);
            raportSumaZadluzenia.Visit(rachunekDebetowy);

            SumaZadluzeniaVisitor = raportSumaZadluzenia.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue( SumaZadluzeniaZmienne == SumaZadluzeniaVisitor );
        }

        [TestMethod]
        public void SumaZadluzeniaProduktowBankowychKwotaMniejszaOdZera()
        {
            WczytajDaneTestowe();
            raportSumaZadluzenia.Visit(kredyt);
            raportSumaZadluzenia.Visit(lokata);
            raportSumaZadluzenia.Visit(rachunekDebetowy);
            long SumaZadluzeniaVisitor = raportSumaZadluzenia.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaZadluzeniaVisitor < 0);
        }

        [TestMethod]
        public void SumaZadluzeniaRownaSalduKredytuPoJegoOdwiedzeniu()
        {
            WczytajDaneTestowe();
            raportSumaZadluzenia.Visit(kredyt);
            long SumaZadluzeniaVisitor = raportSumaZadluzenia.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaZadluzeniaVisitor == kredytSaldo);
        }

        [TestMethod]
        public void SumaZadluzeniaNieDotyczyLokatyPoJejOdwiedzeniuRowna0()
        {
            WczytajDaneTestowe();
            raportSumaZadluzenia.Visit(lokata);
            long SumaZadluzeniaVisitor = raportSumaZadluzenia.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaZadluzeniaVisitor == 0);
        }


        [TestMethod]
        public void SumaZadluzeniaRownaSalduRachunkuDebetowegoPoJegoOdwiedzeniu()
        {
            WczytajDaneTestowe();
            raportSumaZadluzenia.Visit(rachunekDebetowy);
            long SumaZadluzeniaVisitor = raportSumaZadluzenia.Calculate(new BankType("test", new KIR()));

            Assert.IsTrue(SumaZadluzeniaVisitor == rachunekDebetowySaldo);
        }
    }
}
