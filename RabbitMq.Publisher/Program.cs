using RabbitMq.Publisher.Exchanges;
using RabbitMQ.Client;

namespace RabbitMq.Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Publisher!");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.Publish();
            }


            Console.ReadLine();
        }
    }
}