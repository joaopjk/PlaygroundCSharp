namespace Decorator.Exercicios
{
    public class Filtrado : ICafe
    {
        public string Decricao()
        {
            return "Café Filtrado";
        }

        public decimal Preco()
        {
            return 4.00m;
        }
    }
}
