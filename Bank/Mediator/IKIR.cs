using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Mediator
{
    public interface IKIR
    {
        void Send(Operacja operacja, BankMediatorReceiver bank);
    }
}
