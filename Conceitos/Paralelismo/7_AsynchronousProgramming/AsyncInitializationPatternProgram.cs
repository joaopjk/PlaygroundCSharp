using System.Threading.Tasks;

namespace _7_AsynchronousProgramming
{
    public interface IAsyncInit
    {
        Task InitTask { get; }
    }

    public class MyClass : IAsyncInit
    {
        public MyClass()
        {
            InitTask = InitAsync();
        }
        public Task InitTask { get; }

        private async Task InitAsync()
        {
            await Task.Delay(1000);
        }
    }
    class AsyncInitializationPatternProgram
    {
        static async void Method()
        {
            var myClass = new MyClass();
            if (myClass is IAsyncInit ai)
            {
                await ai.InitTask;
            }
        }
    }
}
