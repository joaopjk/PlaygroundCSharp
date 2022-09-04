using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Classes
{/*
  * Channel<T>:Fornece uma classe raiz para canais que dão suporte à leitura e gravação de elementos do tipo T. Atua de forma
  * semelhante ao tipo Queue<T>, como benefícios adicionais. Pode ser entendido com uma estrutura básica para estabelecer uma
  * conexão entre produtores e consumidores. Atua de simultanea, utilizando thread-safe eficiente. Publishers -> Subscribers.
  * Faz a correção do balance entre produtores e consumidores. Permite que vários threads podem ser lidos/gravados no mesmo
  * canal sem nenhum problema.
  */
  static class ClasseChannel
  {
    static async Task Main(string[] _)
    {
      /*
       * Criar uma canal sem capacidade definida pode ser perigoso, já que dessa forma a classe pode consumir toda a 
       * memória RAM disponível.
       */
      var meuChannel = Channel.CreateUnbounded<int>();

      for (int i = 0; i < 10; i++)
      {
        await meuChannel.Writer.WriteAsync(i);
      }

      while (true)
      {
        var item = await meuChannel.Reader.ReadAsync();
        Console.WriteLine($"{item}");
      }

      /* Principais métodos:
       * CreateBounded<T>(int capacity): Criar uma canal com capacidade definida. Quando atingir a capacidade máxima ele
       * vai poder receber uma nova mensagem depois que uma mensagem for consumida.
       * Channel<T> CreateBounded<T>(BoundedChannelOptions options): Permite possibilidades de definições de opções para
       * denotar o comportamento do canal durante uma operação de gravação quando o canal estiver cheio.
       *  - Wait: espera que o canal tenha espaço para completar uma operação de escrita
       *  - DropNewest: Descarta o item mais novo escrito mas ainda não lido
       *  - DropOldest: descarta o item mais antigo mas ainda não lido
       *  - DropWrite: Descarta um item que esteja sendo escrito no canal
       * Channel<T> CreateUnbounded<T>(): Criar uma canal com capacidade ilimitada.
       * Channel<T> CreateUnbounded<T>(UnboundedChannelOptions options): Permite definições de opções por canal.
       * 
       * SingleWrite: Quando true, garante que vai ocorrer apenas uma operação de escrita por vez.
       * SingleReader: Como a anterior, mas para leitura.
       */
    }
  }
}
