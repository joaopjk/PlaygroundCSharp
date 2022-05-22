using System;

namespace Facade.Subsistema
{
    public class LimiteCredito
    {
        public bool PossuiLimiteCredito(Cliente cliente, double valor)
        {
            Console.WriteLine("Verificando limite de crédito " + cliente.Nome);
            if (valor > 200000)
                return false;
            return true;
        }
    }
}
