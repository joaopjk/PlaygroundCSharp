using System;

namespace Flyweight
{
    public class Soldado : IPersonagem
    {
        // Estado extrínseco (não compartilhável)
        // Muda para cada objeto
        public int Poder { get; set; }

        // Estado intríseco (cache - compatilhável)
        // É o mesmo para cada objeto
        public string Arma = "Fuzil e Pistola";
        public string Atuacao = "Luta Corpotal";
        public string Defesa = "Colete e capacete";

        public Soldado() { }
        public Soldado(int poder)
        {
            Poder = poder;
        }
        public void Render()
        {
            Console.WriteLine($"Soldado: {Poder} - Arma: {Arma} - Defesa: {Defesa} - Atuação: {Atuacao}");
        }
    }
}
