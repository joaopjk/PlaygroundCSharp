using System;

namespace Bridge.Exercicio
{
    public class GeraXml : IGerarArquivo
    {
        public void GerarArquivo(Funcionario funcionario)
        {
            Console.WriteLine("Gerando XML do Funcionario:" + funcionario.ToString());
        }
    }
}
