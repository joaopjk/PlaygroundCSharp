using System;
using System.Collections.Generic;

namespace Adpter.Exercicio
{
    public class MeuGeradorGrafico : IGrafico
    {
        public string Titulo { get; set; }
        public List<string> XValores { get; set; }
        public List<int> YValores { get; set; }
        public void GerarGrafico(string titulo, List<string> xValores, List<int> yValores)
        {
            Console.WriteLine("MeuGeradorGrafico: GerandoGrafico");
        }
    }
}
