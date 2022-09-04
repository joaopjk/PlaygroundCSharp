using System;

namespace Flyweight
{
    internal class Program
    {
        static void Main(string[] _)
        {
            for (int i = 0; i < 5; i++)
            {
                var pesonagem = (Soldado)PersonagemFactory.GetPersonagem("soldado");
                pesonagem.Poder = GetRandomPower();
                pesonagem.Render();
            }

            Console.WriteLine("_______________________________________________________________");

            for (int i = 0; i < 5; i++)
            {
                var pesonagem = (Piloto)PersonagemFactory.GetPersonagem("piloto");
                pesonagem.Poder = GetRandomPower();
                pesonagem.Render();
            }
        }

        private static int GetRandomPower()
        {
            var random = new Random();
            return random.Next(10,100);
        }
    }
}
