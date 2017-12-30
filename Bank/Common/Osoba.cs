using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Osoba
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Plec { get; set; }
        public DateTime DataUrodzenia { get; set; }

        public Osoba(string pesel, string imie, string nazwisko)
        {
            Id = _id;
            _id++;

            Pesel = pesel;
            Imie = imie;
            Nazwisko = nazwisko;
        }
    }
}
