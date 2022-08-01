using System;

namespace Proxy
{
    //RealSubject
    //Objeto que queremos usar de forma mais eficiente usando a classe proxy
    public class PastaCompartilhada : IPastaCompartilhada
    {
        public void OperacaoDeLeituraGravacao()
        {
            Console.WriteLine("#################### Operação de Leitura e Escrita sendo executada");
        }
    }
}
