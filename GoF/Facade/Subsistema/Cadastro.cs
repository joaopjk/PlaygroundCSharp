using System;

namespace Facade.Subsistema
{
    public class Cadastro
    {
        public void CadastrarCliente(Cliente cliente)
        {
            Console.WriteLine($"Cadastro do cliente {cliente.Nome} sem pendências");
        }
    }
}
