using System.Collections.Generic;

namespace Bank
{
    public interface IBankCommandReceiver
    {
        void WykonajOperacje(Operacja operacja);
    }
}