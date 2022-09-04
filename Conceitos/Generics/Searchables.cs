using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Listas
{
    class Searchables
    {
        static void Main(string[] _)
        {
            List<Quadrado> quadrados = new List<Quadrado>()
            {
                new Quadrado(4,3),
                new Quadrado(2,1),
                new Quadrado(6,1)
            };

            IComparer<Quadrado> comparer = new CompararAlturaQuadrado();
            quadrados.Sort(comparer);
        }

        class Quadrado
        {
            public int Altura { get; set; }
            public int Largura { get; set; }

            public Quadrado() { }

            public Quadrado(int altura, int largura)
            {
                Altura = altura;
                Largura = largura;
            }
        }

        class CompararAlturaQuadrado : IComparer<Quadrado>
        {
            public int Compare([AllowNull] object x, [AllowNull] object y)
            {
                if (!(x is Quadrado quadrado1) || !(y is Quadrado quadrado2))
                    throw new ArgumentException("Ambos os parâmetros tem que ser do tipo quadrado !");
                else
                    return Compare(quadrado1, quadrado2);
            }

            public int Compare([AllowNull] Quadrado x, [AllowNull] Quadrado y)
            {
                if (x.Altura == y.Altura)
                    return 0;
                else if (x.Altura > y.Altura)
                    return 1;
                else if (x.Altura < y.Altura)
                    return -1;
                else
                    return -1;
            }
        }
    }
}
