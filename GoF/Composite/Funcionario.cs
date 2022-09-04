using System;

namespace Composite
{
    //Leaf
    internal class Funcionario : HoraTrabalhada
    {
        public int Horas { get; set; }
        public override int GetHoraTrabalhada()
        {
            Console.WriteLine($"O funcionário {Nome} registrou {Horas} trabalhadas");
            return Horas;
        }
    }
}
