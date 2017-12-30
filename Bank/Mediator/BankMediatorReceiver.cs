using System;

namespace Bank.Mediator
{
    public abstract class BankMediatorReceiver
    {
        private IKIR _kir;

        public BankMediatorReceiver(IKIR kir) 
        {
            _kir = kir ?? throw new ArgumentNullException();
        }

        public void Send(Operacja operacja)
        {
            _kir.Send(operacja, this);
        }

        public abstract void Receive(Operacja operacja);
    }
}