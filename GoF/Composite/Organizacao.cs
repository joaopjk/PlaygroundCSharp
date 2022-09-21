using System;
using System.Collections.Generic;

namespace Composite
{
    //Composite
    public class Organizacao : HoraTrabalhada
    {
        protected List<HoraTrabalhada> departamentos = new();
        public override void Add(HoraTrabalhada component)
        {
            departamentos.Add(component);
        }
        public override int GetHoraTrabalhada()
        {
            var horasTrabalhadas = 0;
            foreach (var departamento in departamentos)
            {
                horasTrabalhadas += departamento.GetHoraTrabalhada();
            }
            Console.WriteLine($"{Nome} registrou um total de {horasTrabalhadas}");
            return horasTrabalhadas;
        }
    }
}
