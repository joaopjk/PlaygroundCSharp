using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    internal class Sender
    {
        static void Main(string[] _)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasisTest", false, false, false, null);
                string message = "Getting started with RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasisTest", null, body);
            }
            Console.ReadKey();
        }
    }
}
