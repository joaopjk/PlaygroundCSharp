using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Exemplo_1
{
    class Program
    {
        static void Main(string[] _)
        {
            Uri _baseAddress = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            var bootstrapper = new Bootstrapper();
            config.DependencyResolver = bootstrapper.Resolver();

            //Create Server
            var server = new HttpSelfHostServer(config);

            //Start listening
            server.OpenAsync().Wait();
            Console.WriteLine("Web api Self hosted on " + _baseAddress + "Hit Enter to exit");
            Console.ReadKey();
            server.CloseAsync().Wait();
        }
    }
}
