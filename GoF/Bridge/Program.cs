namespace Bridge
{
    class Program
    {
        static void Main(string[] _)
        {
            Funcionario funcionario = new()
            {
                Id = 1,
                Nome = "João Cícero Vicente Sousa",
                SalarioBase = 6000M,
                Incentivo = 30000M
            };

            GerarJson gerarJson = new();
            GerarXML gerarXml = new();

            CalcularSalario calcularSalarioJson = new(gerarJson);
            calcularSalarioJson.ProcessarioSalario(funcionario);

            CalcularSalario calcularSalarioXml = new(gerarXml);
            calcularSalarioXml.ProcessarioSalario(funcionario);
        }
    }
}
