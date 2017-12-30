namespace Bank
{
    public class OdsetkiDuze : IOdsetki
    {
        public long Wartosc { get; set; }

        public ProduktBankowy ProduktBankowy { get; set; }

        public void Oblicz()
        {
            Wartosc = ProduktBankowy.Saldo / 10;
        }
    }
}
