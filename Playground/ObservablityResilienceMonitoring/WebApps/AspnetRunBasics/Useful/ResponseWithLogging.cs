using AspnetRunBasics.Extensions;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Useful
{
    public class ResponseWithLogging
    {
        public static async Task<T> Generate<T>(HttpResponseMessage response, ILogger logger,string classifiedName)
        {
            var respose = await response.ReadContentAs<T>();
            logger.LogInformation($"{classifiedName} Response: {respose.ToString()}");
            return respose;
        }
    }
}
