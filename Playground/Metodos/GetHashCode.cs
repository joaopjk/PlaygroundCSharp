using System;

namespace Metodos
{/*
  *É um método de Object que é herdado por todos os objetos da linguagem C#. Este método serve como função hash padrão.
  *Hase: é um valor numérico que é usado para inserir e identificar um objeto em uma coleção baseado em hash, como a classe
  *Dictionary<Key,Value>, a classe HashTable ou um tipo derivado da classe DicionaryBase.
  *O método fornerce esse código hash para algoritimos que necessitam realizar verificações rápidas de igualdade entre objetos,
  *comparando elas pelo seu valor.
  */
    class GetHashCode
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Demo
    {
        public double Numero { get; set; }
        public double Resultado { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Demo demo &&
                   Resultado == demo.Resultado;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Resultado);
        }
    }
}
