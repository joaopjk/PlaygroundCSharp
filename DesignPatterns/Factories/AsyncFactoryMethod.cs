using System.Threading.Tasks;

namespace Factories
{
  public class Foo
  {
    public async Task<Foo> InitAsync()
    {
      await Task.Delay(1000);
      return this;
    }

    public static Task<Foo> CreateAsync()
    {
      var result = new Foo();
      return result.InitAsync();
    }
  }
}