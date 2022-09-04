using AirlineSendAgent.App;
using AirlineSendAgent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AirlineSendAgent
{
  internal static class Program
  {
    static void Main(string[] _)
    {
      var host = Host.CreateDefaultBuilder()
          .ConfigureServices((_, services) =>
          {
            services.AddSingleton<IAppHost, AppHost>();
            services.AddDbContext<SendAgentDbContext>(x =>
                  x.UseSqlServer("Server=127.0.0.1,1433;Database=Webhooks;user id=SA;Password=Root@123root"));
            services.AddHttpClient();
          })
          .Build();
      host.Services.GetService<IAppHost>().Run();
    }
  }
}
