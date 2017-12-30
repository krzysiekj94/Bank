using Bank.RaportVisitor;
using System;
using System.Collections.Generic;

namespace Bank
{
    public class Rachunek : ProduktBankowy, IProduktBankowyElement
    {
        public DateTime DataZalozenia { get; set; }
        public DateTime DataZamkniecia { get; set; }

        public Rachunek()
        {
            HistoriaOperacji = new List<Operacja>();
            Saldo = 0;
            DataZalozenia = DateTime.Now;
            DataZamkniecia = DateTime.MinValue;
        }

        public override void WykonajOperacje(Operacja operacja)
        {
            operacja.Wykonaj();
            HistoriaOperacji.Add(operacja);
        }

        public void Accept(IRaportVisitor v)
        {
            v.Visit(this);
        }
    }
}
