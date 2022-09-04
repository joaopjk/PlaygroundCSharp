using System;

namespace Proxy
{
    public class PastaCompartilhadaProxy : IPastaCompartilhada
    {
        //Proxy
        //Contém uma referência a classe RealSubject e pode acessar os membos da classe RealSubject conforme necessário.

        private IPastaCompartilhada pasta;
        private Funcionario funcionario;

        public PastaCompartilhadaProxy(Funcionario funcionario)
        {
            this.funcionario = funcionario;
        }

        public void OperacaoDeLeituraGravacao()
        {
            if (funcionario.Perfil.ToUpper() == "CEO")
            {
                pasta = new PastaCompartilhada();
                Console.WriteLine("Invocando a pasta real");
                pasta.OperacaoDeLeituraGravacao();
            }
            else
            {
                Console.WriteLine("Você não tem permissão para usar a pasta.");
            }
        }
    }
}
