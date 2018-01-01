using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.Mediator;
using Bank;

namespace BankTestyJednostkowe
{
    [TestClass]
    public class PrzelewMiedzybankowyTests
    {
        KIR kir;
        BankType bankNadawca;
        BankType bankOdbiorca;
        PrzelewOut przelewOperacja;
        long kwotaPrzelewu;

        void WczytajDaneTestowe()
        {
            kwotaPrzelewu = 1000;
            kir = new KIR();
            bankNadawca = new BankType("Bank nadawcy", kir);
            bankOdbiorca = new BankType("Bank odbiorcy", kir);
            kir.AddBank(bankNadawca);
            kir.AddBank(bankOdbiorca);

            bankNadawca.WykonajOperacje(new OtworzProduktBankowy(new Rachunek(), new Klient("123456785","Krzysiek","Zbyszko"), bankNadawca));
            bankOdbiorca.WykonajOperacje(new OtworzProduktBankowy(new Rachunek(), new Klient("123456786", "Macko", "Wielki"), bankOdbiorca));
            bankOdbiorca.WykonajOperacje(new OtworzProduktBankowy(new Rachunek(), new Klient("12332123456", "Zbyszko", "Polak"), bankOdbiorca));

            bankNadawca.ProduktyBankowe[0].Saldo = 1000;
            bankOdbiorca.ProduktyBankowe[0].Saldo = 5000;
            bankOdbiorca.ProduktyBankowe[1].Saldo = 2000;
        }

        [TestMethod]
        public void SaldoRachunkuOdbiorcyJestPowiekszoneOKwotePrzelewu()
        {
            WczytajDaneTestowe();

            long kwotaPrzed = bankOdbiorca.ProduktyBankowe[0].Saldo;
            long kwotaPo = 0;

            przelewOperacja = new PrzelewOut(bankNadawca.ProduktyBankowe[0], bankOdbiorca.ProduktyBankowe[0], kwotaPrzelewu);
            kir.Send(przelewOperacja, bankOdbiorca);

            kwotaPo = bankOdbiorca.ProduktyBankowe[0].Saldo;

            Assert.IsTrue(kwotaPrzed + kwotaPrzelewu == kwotaPo);
        }

        [TestMethod]
        public void SaldoKontaNadawcyJestUmniejszonyOKwotePrzelewu()
        {
            WczytajDaneTestowe();

            long kwotaPrzed = bankNadawca.ProduktyBankowe[0].Saldo;
            long kwotaPo = 0;

            przelewOperacja = new PrzelewOut(bankNadawca.ProduktyBankowe[0], bankOdbiorca.ProduktyBankowe[0], kwotaPrzelewu);
            kir.Send(przelewOperacja, bankOdbiorca);
            kwotaPo = bankNadawca.ProduktyBankowe[0].Saldo;

            Assert.IsTrue(kwotaPrzed - 1000 == kwotaPo );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProbaPrzelaniaUjemnejKwotyPowinnaZwrocicAsercje()
        {
            WczytajDaneTestowe();

            kwotaPrzelewu = -1200;

            long kwotaPrzed = bankOdbiorca.ProduktyBankowe[0].Saldo;
            long kwotaPo = 0;

            przelewOperacja = new PrzelewOut(bankNadawca.ProduktyBankowe[0], bankOdbiorca.ProduktyBankowe[0], kwotaPrzelewu);
            kir.Send(przelewOperacja, bankOdbiorca);

            kwotaPo = bankOdbiorca.ProduktyBankowe[0].Saldo;
        }

        [TestMethod]
        public void StanSaldaRachunku2WBankuOdbiorcyNieZmieniStanuPoPrzelewie()
        {
            WczytajDaneTestowe();

            long kwotaPrzed = bankOdbiorca.ProduktyBankowe[1].Saldo;
            long kwotaPo = 0;

            przelewOperacja = new PrzelewOut(bankNadawca.ProduktyBankowe[0], bankOdbiorca.ProduktyBankowe[0], kwotaPrzelewu);
            kir.Send(przelewOperacja, bankOdbiorca);
            kwotaPo = bankOdbiorca.ProduktyBankowe[1].Saldo;

            Assert.IsTrue(kwotaPrzed == kwotaPo);
        }
    }
}
