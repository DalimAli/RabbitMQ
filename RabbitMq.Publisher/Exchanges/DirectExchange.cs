using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMq.Publisher.Exchanges
{
    public static class DirectExchange
    {
        public static void Publish(this IModel channel)
        {
            Console.WriteLine("Hello, Direct Publisher!");
            channel.QueueDeclare(queue: "message-test", durable: false, exclusive: false, autoDelete: false);
            var count = 1;
            while (true)
            {
                var message = new { Name = "Dalim", Message = "Checking queue publish", Count = count };
                var stringMessage = JsonConvert.SerializeObject(message);

                var byteArray = Encoding.UTF8.GetBytes(stringMessage);

                channel.BasicPublish("", "message-test", null, byteArray);
                Console.WriteLine(" [x] Sent {0}", stringMessage);
                count++;

                Thread.Sleep(1000);
            }
        }
    }
}
