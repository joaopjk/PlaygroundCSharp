using System;

namespace Parte_01
{
    internal class Program
    {
        static void Main(string[] _)
        {
            #region Matriz
            string aulaIntro = "Introdução as coleçãos";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";
            //string[] aulas = new string[]{ aulaIntro, aulaModelando, aulaSets };
            //string[] aulas = new string[3] {aulaIntro,aulaModelando,aulaSets};
            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;
            foreach (string s in aulas) Console.WriteLine(s);
            #endregion
        }
    }
}
