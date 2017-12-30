namespace Bank
{
    public class OdsetkiSrednie : IOdsetki
    {
        public long Wartosc { get; set; }

        public void Oblicz()
        {
            Wartosc = 5;
        }
    }
}
