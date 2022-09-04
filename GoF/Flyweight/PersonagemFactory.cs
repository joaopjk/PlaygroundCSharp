using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class PersonagemFactory
    {
        private static Dictionary<string, IPersonagem> pesonagemMap = new();

        public static IPersonagem GetPersonagem(string tipo)
        {
            IPersonagem personagem;

            if (pesonagemMap.ContainsKey(tipo))
            {
                Console.WriteLine($">>> Retornando personagem do cache: {tipo} >>>");
                return pesonagemMap[tipo];
            }
            else
            {
                Console.WriteLine($"### Instanciando um novo personagem: {tipo} ###");
                if (tipo == "soldado")
                {
                    personagem = new Soldado();
                    pesonagemMap.Add("soldado", personagem);
                }
                else if (tipo == "piloto")
                {
                    personagem = new Piloto();
                    pesonagemMap.Add("piloto", personagem);
                }

                else
                    throw new Exception("Esse tipo de pesonagem não pode ser criado !");
            }
            return personagem;
        }
    }
}
