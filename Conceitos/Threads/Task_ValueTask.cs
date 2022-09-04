using System.Threading.Tasks;

namespace Threads
{
    class Task_ValueTask
    {/*
      * Umas taks representa o estado de alguma operação, ou seja, se a operação está concluída, cancelada e assim por diante
      * Um método assíncrono pode retornar um Taks ou um ValueTask.
      * Como a Task é um tipo referência, retornar um objeto Taks de um método assíncrono implica alocar o objeto no heap 
      * gerenciado toda vez que o método for chamado. Portanto, uma ressalva ao usar a Task é que você precisar alocar mémoria
      * no heap toda vez que retornar um objeto Task no seu método. Se o resultado da operação executado por seu método estiver
      * disponível imediatamente ou for concluído de forma síncrona, essa alocação não será necessária e, portanto, será 
      * custosa. Para esses casos utilizamos ValuesTask
      * 
      * Beneficíos
      * - Ele melhora o desempenho porque não precisar de alocação de heap
      * - É fácil e flexível de implementar
      * 
      */

        class Demo
        {
            public async Task<int> TesteTask(int d)
            {
                await Task.Delay(d);
                return 10;
            }

            public async ValueTask<int> TesteValueTask(int d)
            {
                await Task.Delay(d);
                return 10;
            }
        }
    }
}
