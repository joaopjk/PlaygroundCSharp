using System;
using System.Threading.Tasks;
using Grpc.Core;
using gRPCHelloWorldServer.Protos;
using Microsoft.Extensions.Logging;

namespace gRPCHelloWorldServer.Services
{
    public class HelloWorldSource : HelloService.HelloServiceBase
    {
        private readonly ILogger<HelloWorldSource> _logger;

        public HelloWorldSource(ILogger<HelloWorldSource> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override Task<HelloResponse> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, request.ToString());
            string resultMessage = $"Hello {request.Name}";
            var response = new HelloResponse()
            {
                Message = resultMessage
            };
            return Task.FromResult(response);
        }
    }
}
