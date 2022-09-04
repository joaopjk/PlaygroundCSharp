namespace Decorator.Exercicios
{
    public class CafeExpresso : ICafe
    {
        public string Decricao()
        {
            return "Café Expresso";
        }

        public decimal Preco()
        {
            return 5.00m;
        }
    }
}
