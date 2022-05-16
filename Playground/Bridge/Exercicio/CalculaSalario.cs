namespace Bridge.Exercicio
{
    internal class CalculaSalario : Arquivo
    {
        public CalculaSalario(IGerarArquivo gerarArquivo) : base(gerarArquivo)
        {
        }

        public void ProcessarSalario(Funcionario funcionario)
        {
            funcionario.SalarioTotal = funcionario.SalarioBase + funcionario.Incentivo;

            gerarArquivo.GerarArquivo(funcionario);
        }
    }
}
