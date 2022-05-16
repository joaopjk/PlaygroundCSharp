using System;

namespace Bridge
{
    internal class EnviaEmail : IDespachaMensagem
    {
        public void EnviaMensagem(string mensagem)
        {
            Console.WriteLine($"### Email : {mensagem}");
        }
    }
}
