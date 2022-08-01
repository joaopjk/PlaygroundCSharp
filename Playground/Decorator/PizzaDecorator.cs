namespace Decorator
{
    //Decorator
    public abstract class PizzaDecorator : IPizza
    {
        protected readonly IPizza _pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string Opcionais()
        {
            return _pizza.Opcionais();
        }

        public virtual decimal Preco()
        {
            return _pizza.Preco();
        }
    }
}
