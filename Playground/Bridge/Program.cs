using Bridge.Exercicio;
using System;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Brideg
            Console.WriteLine("(1) Mensagem normal (2) Mensagem com anexo");
            int tipoMensagem = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a mensagem que quer enviar");
            string minhaMensagem = Console.ReadLine();

            Console.WriteLine("(1) Envia via Email (2) Envia via SMS");
            int tipoEnvio = Convert.ToInt32(Console.ReadLine());

            if (tipoMensagem == 1)
            {
                if (tipoEnvio == 1)
                {
                    Mensagem normal = new MensagemNormal(new EnviaEmail());
                    normal.EnviaMensagem(minhaMensagem);
                }
                else
                {
                    Mensagem normal = new MensagemNormal(new EnviaSMS());
                    normal.EnviaMensagem(minhaMensagem);
                }
            }
            else
            {
                if (tipoEnvio == 1)
                {
                    Mensagem anexo = new MensagemAnexo(new EnviaEmail());
                    anexo.EnviaMensagem(minhaMensagem);
                }
                else
                {
                    Mensagem anexo = new MensagemAnexo(new EnviaSMS());
                    anexo.EnviaMensagem(minhaMensagem);
                }
            }
            #endregion
            #region Exc

            var funcionario = new Funcionario()
            {
                Id = 1,
                Nome = "João",
                SalarioBase = 6000,
                Incentivo = 500
            };

            CalculaSalario calculaSalarioXml = new(new GeraXml());
            calculaSalarioXml.ProcessarSalario(funcionario);
            CalculaSalario calculaSalarioJson = new(new GerarJson());
            calculaSalarioJson.ProcessarSalario(funcionario);
            #endregion
            Console.ReadKey();
        }
    }
}
