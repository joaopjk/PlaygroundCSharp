namespace Decorator.Exercicios
{
    public class ChocolateDecorator : OpcionalDecorator
    {
        public ChocolateDecorator(ICafe cafe) : base(cafe)
        {
            _opcional = "   mais generosa porção de chocolate";
            _preco = 4.00m;
        }
    }
}
