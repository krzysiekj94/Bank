using Bank.RaportVisitor;
using System;
using System.Collections.Generic;

namespace Bank
{
    public class KredytObj : Kredyt, IProduktBankowyElement
    { 
        public DateTime DataZalozenia { get; set; }
        public DateTime DataZamkniecia { get; set; }

        public KredytObj()
        {
            HistoriaOperacji = new List<Operacja>();
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
