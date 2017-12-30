namespace Bank
{
    public class OdsetkiMale : IOdsetki
    {
        public long Wartosc { get; set; }

        public void Oblicz()
        {
            Wartosc = 1;
        }
    }
}
