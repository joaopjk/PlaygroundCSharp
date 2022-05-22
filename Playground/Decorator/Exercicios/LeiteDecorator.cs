namespace Decorator.Exercicios
{
    internal class LeiteDecorator : OpcionalDecorator
    {
        public LeiteDecorator(ICafe cafe) : base(cafe)
        {
            _opcional = "   mais porção de leite";
            _preco = 2.00m;
        }
    }
}
