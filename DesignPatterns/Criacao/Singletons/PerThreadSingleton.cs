using System.Threading;

namespace Singletons
{
  public sealed class PerThreadSingleton
  {
    private static readonly ThreadLocal<PerThreadSingleton> threadInstance
     = new(() => new PerThreadSingleton());
    public int Id;
    private PerThreadSingleton()
    {
      Id = Thread.CurrentThread.ManagedThreadId;
    }
    public static PerThreadSingleton Instance = threadInstance.Value;
  }
}