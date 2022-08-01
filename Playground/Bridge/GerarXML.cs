namespace Bridge
{
    public class GerarXML : IGerarArquivo
    {
        public void GerarArquivo(Funcionario funcionario)
        {
            System.Console.WriteLine("Gerar XML " + funcionario.Nome);
        }
    }
}
