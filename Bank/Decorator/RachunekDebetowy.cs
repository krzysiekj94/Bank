using Bank.RaportVisitor;
using System;

namespace Bank
{
    public class RachunekDebetowy : ProduktBankowy, IProduktBankowyElement
    {
        private Rachunek _rachunek = null;

        public RachunekDebetowy(Rachunek rachunek)
        {
            _rachunek = rachunek ?? throw new ArgumentNullException(nameof(rachunek));
        }

        public override void WykonajOperacje(Operacja operacja)
        {
            _rachunek.WykonajOperacje(operacja);
        }

        public void Accept(IRaportVisitor v)
        {
            v.Visit(this);
        }
    }
}
