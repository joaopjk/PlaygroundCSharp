namespace Bridge
{
    public class GerarJson : IGerarArquivo
    {
        public void GerarArquivo(Funcionario funcionario)
        {
            System.Console.WriteLine("Gerar Json " + funcionario.Nome);
        }
    }
}
