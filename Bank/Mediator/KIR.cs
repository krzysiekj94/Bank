using System.Collections.Generic;

namespace Bank.Mediator
{
    public class KIR : IKIR
    {
        private ICollection<BankMediatorReceiver> _banks;

        public KIR()
        {
            _banks = new List<BankMediatorReceiver>();
        }

        public void AddBank(BankMediatorReceiver bank)
        {
            _banks.Add(bank);
        }

        public void Send(Operacja operacja, BankMediatorReceiver bank)
        {
            foreach (var b in _banks)
            {
                if(b != bank)
                {
                    b.Receive(operacja);
                }
            }
        }
    }
}
