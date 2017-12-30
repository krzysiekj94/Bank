using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Klient : Osoba
    {
        public Klient(string pesel, string imie, string nazwisko)
            :base(pesel, imie, nazwisko)
        {
        }
    }
}
