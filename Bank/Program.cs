using Bank.Mediator;
using Bank.RaportVisitor;
using System;

//KIR - obiekt do przekazywania info miedzy bankami (use mediator)

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var kir = new KIR();
            var bank = new BankType("Test1", kir);
            var bank2 = new BankType("Test2", kir);
            var bank3 = new BankType("Test3", kir);
            kir.AddBank(bank);
            kir.AddBank(bank2);
            kir.AddBank(bank3);

            var klient = new Klient("11111111111", "a", "b");

            var rachunek = new Rachunek();
            var rachunek2 = new Rachunek();

            bank.WykonajOperacje(new OtworzProduktBankowy(rachunek, klient, bank));
            bank.WykonajOperacje(new OtworzProduktBankowy(rachunek2, klient, bank2));
            rachunek.Saldo = 1000;
            rachunek2.Saldo = 1000;

            var dodajKlienta = new DodajKlienta(klient, bank);
            bank.WykonajOperacje(dodajKlienta);

            Console.WriteLine($"Rachunek {rachunek.Id}: {rachunek.Saldo}");
            Console.WriteLine($"Rachunek2 {rachunek2.Id}: {rachunek2.Saldo}");
            kir.Send(new PrzelewOut(rachunek, rachunek2, 200), bank);
            Console.WriteLine($"Rachunek {rachunek.Id}: {rachunek.Saldo}");
            Console.WriteLine($"Rachunek2 {rachunek2.Id}: {rachunek2.Saldo}");

            var otworz = new OtworzProduktBankowy(rachunek, klient, bank);
            bank.WykonajOperacje(otworz);

            var otworz2 = new OtworzProduktBankowy(rachunek2, klient, bank2);
            bank.WykonajOperacje(otworz2);

            var wplata = new Wplata(rachunek, 100);
            bank.WykonajOperacje(wplata);

            var wyplata = new Wyplata(rachunek, 500);
            bank.WykonajOperacje(wyplata);

            Console.WriteLine(rachunek.Saldo);

            var raport = new SumaSald();
            var raportResult = raport.Calculate(bank);
            Console.WriteLine($"Wynik raportu: {raportResult}");

            Console.WriteLine("Produkty klienta:");
            foreach (var produkt in bank.PobierzProduktyBankoweKlienta(klient))
            {
                Console.WriteLine(produkt.Id);
            }

            Console.ReadLine();
        }
    }
}