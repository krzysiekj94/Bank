namespace Bank.RaportVisitor
{
    public class SumaZadluzenia : IRaportVisitor
    {
        private long _sum = 0;

        public void Visit(Rachunek o)
        {
        }

        public void Visit(RachunekDebetowy o)
        {
            if(o.Saldo < 0)
            {
                _sum += o.Saldo;
            }
        }

        public void Visit(Kredyt o)
        {
            _sum += o.Saldo;
        }

        public void Visit(Lokata o)
        {
        }

        public long Calculate(BankType bank)
        {
            _sum = 0;
            foreach(var pb in bank.ProduktyBankowe)
            {
                if(pb is IProduktBankowyElement)
                {
                    var pbElem = pb as IProduktBankowyElement;
                    pbElem.Accept(this);
                }
            }
            return _sum;
        }
    }
}
