namespace Proxy
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public Funcionario(string nome, string perfil)
        {
            Nome = nome;
            Perfil = perfil;
        }

    }
}
