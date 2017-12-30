namespace Bank.RaportVisitor
{
    public interface IProduktBankowyElement
    {
        void Accept(IRaportVisitor v);
    }
}
