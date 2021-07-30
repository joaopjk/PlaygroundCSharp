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
        }
    }
}
