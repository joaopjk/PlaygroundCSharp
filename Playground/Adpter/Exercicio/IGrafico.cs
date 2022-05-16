using System.Collections.Generic;

namespace Adpter.Exercicio
{
    public interface IGrafico
    {
        string Titulo { get; set; }
        List<string> XValores { get; set; }
        List<int> YValores { get; set; }
        void GerarGrafico(string titulo, List<string> xValores, List<int> yValores);
    }
}
