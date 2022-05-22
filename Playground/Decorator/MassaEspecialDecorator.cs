namespace Decorator
{
    internal class MassaEspecialDecorator : PizzaDecorator
    {
        public MassaEspecialDecorator(IPizza pizza) : base(pizza) { }

        public override string Opcionais()
        {
            return $"{base.Opcionais()}\r\n com massa especial";
        }

        public override decimal Preco()
        {
            return base.Preco() + 2.5m;
        }
    }
}
