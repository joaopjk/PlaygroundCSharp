using Grpc.Net.Client;
using GrpcHelloWorldClient.Protos;
using System;
using System.Threading.Tasks;

namespace GrpcHelloWorldClient
{
  static class Program
  {
    static async Task Main(string[] _)
    {
      using var channel = GrpcChannel.ForAddress("https://localhost:5001");
      var client = new HelloService.HelloServiceClient(channel);

      var reply = await client.SayHelloAsync(
              new HelloRequest { Name = "Hello SWN Client" }
          );

      Console.WriteLine("Greetings: " + reply.Message);
    }
  }
}
