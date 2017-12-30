using Bank.Mediator;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    public class BankType : BankMediatorReceiver, IBankCommandReceiver
    {
        public string Nazwa { get; set; }
        public IList<Operacja> HistoriaOperacji { get; set; }
        public IList<ProduktBankowy> ProduktyBankowe { get; set; }
        public IList<Osoba> Klienci { get; set; }
        public BankType(string nazwa, IKIR kir) : base(kir)
        {
            Nazwa = nazwa;
            HistoriaOperacji = new List<Operacja>();
            Klienci = new List<Osoba>();
            ProduktyBankowe = new List<ProduktBankowy>();
        }
        public void WykonajOperacje(Operacja operacja)
        {
            operacja.Wykonaj();
            HistoriaOperacji.Add(operacja);
        }

        public IList<ProduktBankowy> PobierzProduktyBankoweKlienta(Osoba osoba)
        {
            return ProduktyBankowe.Where(p => p.Wlasciciel.Id == osoba.Id).ToList();
        }

        public override void Receive(Operacja operacja)
        {
            if(operacja is PrzelewOut)
            {
                var oper = operacja as PrzelewOut;
                foreach (var produkt in ProduktyBankowe)
                {
                    if(produkt.Id == oper.Na.Id)
                    {
                        oper.Wykonaj();
                        Send(new PrzelewCallback(oper.Z, oper.Na, oper.Kwota));
                        return;
                    }
                }
            }
            if(operacja is PrzelewCallback)
            {
                var oper = operacja as PrzelewCallback;
                foreach (var produkt in ProduktyBankowe)
                {
                    if (produkt.Id == oper.Z.Id)
                    {
                        oper.Wykonaj();
                        return;
                    }
                }
            }
        }
    }
}