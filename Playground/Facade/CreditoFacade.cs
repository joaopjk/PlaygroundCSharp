using Facade.Subsistema;

namespace Facade
{
    internal class CreditoFacade
    {
        private LimiteCredito limite;
        private Serasa serasa;
        private Cadin cadin;
        private Cadastro cadastro;

        public CreditoFacade(LimiteCredito limite, Serasa serasa, Cadin cadin, Cadastro cadastro)
        {
            this.limite = limite;
            this.serasa = serasa;
            this.cadin = cadin;
            this.cadastro = cadastro;
        }

        public bool ConcederEmprestimo(Cliente cliente,double valor)
        {
            cadastro.CadastrarCliente(cliente);

            bool concederEmprestimo = true;

            if (serasa.EstaNoSerasa(cliente))
            {
                System.Console.WriteLine($"Cliente {cliente.Nome} poussui restrição no SERASA");
                concederEmprestimo = false;
            }
            else if (cadin.EstaNoCadin(cliente))
            {
                System.Console.WriteLine($"Cliente {cliente.Nome} poussui restrição no Cadin");
                concederEmprestimo = false;
            }
            else if (limite.PossuiLimiteCredito(cliente,valor))
            {
                System.Console.WriteLine($"Cliente {cliente.Nome} não possui limite de crédito");
                concederEmprestimo = false;
            }
            return concederEmprestimo;   
        }
    }
}
