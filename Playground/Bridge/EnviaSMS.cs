using System;

namespace Bridge
{
    public class EnviaSMS : IDespachaMensagem
    {
        public void EnviaMensagem(string mensagem)
        {
            Console.WriteLine($"### SMS : {mensagem}");
        }
    }
}
