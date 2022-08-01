namespace Bridge
{
    public class CalcularSalario : Arquivo
    {
        public CalcularSalario(IGerarArquivo gerarArquivo) : base(gerarArquivo) { }
        public void ProcessarioSalario(Funcionario funcionario)
        {
            funcionario.SalarioTotal = funcionario.SalarioBase + funcionario.Incentivo;
            System.Console.WriteLine($"Valor do Salario para o funcionario {funcionario.Nome} R${funcionario.SalarioTotal}");
            gerarArquivo.GerarArquivo(funcionario);
        }
    }
}
