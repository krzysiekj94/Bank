using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Pracownik : Osoba
    {
        public string Stanowisko { get; set; }

        public Pracownik(string pesel, 
            string imie, 
            string nazwisko,
            string stanowisko)
            :base(pesel, 
                 imie, 
                 nazwisko)
        {
            Stanowisko = stanowisko;
        }
    }
}
