using Grpc.Core;
using gRPCHelloWorldServer.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gRPCHelloWorldServer.Services
{
    public class HelloWorldService : HelloService.HelloServiceBase
    {
        private readonly ILogger<HelloWorldService> _logger;

        public HelloWorldService(ILogger<HelloWorldService> logger)
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
