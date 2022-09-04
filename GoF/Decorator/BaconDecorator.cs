namespace Decorator
{
    public class BaconDecorator : PizzaDecorator
    {
        public BaconDecorator(IPizza pizza) : base(pizza) { }

        public override string Opcionais()
        {
            return $"{base.Opcionais()}\r\n com porção extra de bacon";
        }

        public override decimal Preco()
        {
            return base.Preco() + 4.00m;
        }
    }
}
