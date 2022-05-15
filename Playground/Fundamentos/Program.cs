using System;

namespace Fundamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class Cliente
        {
            //Campos
            public int Id { get; set; }
            //Métodos
            public string EnterTheVoid()
            {
                return "";
            }
        }
    }
}
