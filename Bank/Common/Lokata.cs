using Bank.RaportVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Lokata : IProduktBankowyElement
    {
        public long Id { get; set; }
        public long Saldo { get; set; }
        public Osoba Wlasciciel { get; set; }
        public DateTime DataZalozenia { get; set; }
        public DateTime DataZamkniecia { get; set; }
        public IList<Operacja> HistoriaOperacji { get; set; }
        public IOdsetki Odsetki { get; set; }

        public Lokata()
        {
            HistoriaOperacji = new List<Operacja>();
        }

        public void WykonajOperacje(Operacja operacja)
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
