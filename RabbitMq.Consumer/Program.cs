using RabbitMq.Consumer.Exchanges;
using RabbitMQ.Client;

namespace RabbitMq.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.Consume();

                Console.ReadLine();
            }            
        }
    }
}