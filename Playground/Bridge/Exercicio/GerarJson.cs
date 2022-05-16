using System;

namespace Bridge.Exercicio
{
    public class GerarJson : IGerarArquivo
    {
        public void GerarArquivo(Funcionario funcionario)
        {
            Console.WriteLine("Gerando Json do Funcionario:" + funcionario.ToString());
        }
    }
}
