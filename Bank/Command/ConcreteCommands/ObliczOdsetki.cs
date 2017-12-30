using System;

namespace Bank
{
    public class ObliczOdsetki : Operacja
    {
        public long Kwota { get; set; }
        public DateTime Czas { get; set; }
        public string Opis { get; set; }
        public ProduktBankowy ProduktBankowy { get; set; }
        public IOdsetki Odsetki { get; set; }

        public override void Wykonaj()
        {
            if(ProduktBankowy == null)
            {
                throw new NullReferenceException(nameof(ProduktBankowy));
            }
            if (Odsetki == null)
            {
                throw new NullReferenceException(nameof(Odsetki));
            }
            ProduktBankowy.Odsetki = Odsetki;
            Odsetki.Oblicz();
        }

        public override string ToString()
        {
            return $"Wyplata: {Kwota}";
        }
    }
}
