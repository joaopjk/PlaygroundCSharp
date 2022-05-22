using Facade.Subsistema;
using System;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var concederEmprestimo = new CreditoFacade(new LimiteCredito(), new Serasa(), new Cadin(), new Cadastro());
            var cliente = new Cliente("João Cícero");

            concederEmprestimo.ConcederEmprestimo(cliente, 2000);
            Console.ReadKey();
        }
    }
}
