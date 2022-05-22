using System;

namespace Flyweight
{
    public class Piloto : IPersonagem
    {
        // Estado extrínseco (não compartilhável)
        // Muda para cada objeto
        public int Poder { get; set; }

        // Estado intríseco (cache - compatilhável)
        // É o mesmo para cada objeto
        public string Arma = "AMX A1: Bombas/Metralhadoas";
        public string Atuacao = "Combate Aéreo";
        public string Defesa = "Velocidade e Altitude";
        public Piloto() { }
        public Piloto(int poder)
        {
            Poder = poder;
        }
        public void Render()
        {
            Console.WriteLine($"Piloto: {Poder} - Arma: {Arma} - Defesa: {Defesa} - Atuação: {Atuacao}");
        }
    }
}
