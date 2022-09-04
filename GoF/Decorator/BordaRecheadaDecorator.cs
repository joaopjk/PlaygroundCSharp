namespace Decorator
{
    public class BordaRecheadaDecorator : PizzaDecorator
    {
        public BordaRecheadaDecorator(IPizza pizza) : base(pizza) { }

        public override string Opcionais()
        {
            return $"{base.Opcionais()}\r\n com borda recheada";
        }

        public override decimal Preco()
        {
            return base.Preco() + 3.00m;
        }
    }
}
