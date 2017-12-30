namespace Bank.RaportVisitor
{
    public interface IRaportVisitor
    {
        void Visit(Rachunek o);
        void Visit(RachunekDebetowy o);
        void Visit(Kredyt o);
        void Visit(Lokata o);
    }
}
