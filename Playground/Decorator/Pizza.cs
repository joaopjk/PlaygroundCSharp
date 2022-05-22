namespace Decorator
{
    //Concrete component
    public class Pizza : IPizza
    {
        public string Nome { get; set; }

        public Pizza(string nome)
        {
            Nome = nome;
        }

        public string Opcionais()
        {
            return $"Pizza de {Nome}";
        }

        public decimal Preco()
        {
            return 10.0m;
        }
    }
}
