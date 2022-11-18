using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMq.Consumer.Exchanges
{
    public static class DirectExchange
    {
        public static void Consume(this IModel channel)
        {
            Console.WriteLine("Hello, Consumer!");
            channel.QueueDeclare(queue: "message-test", durable: false, exclusive: false, autoDelete: false, null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var messageArray = ea.Body.ToArray();
                var stringMesssage = Encoding.UTF8.GetString(messageArray);

                Console.WriteLine("Received message {0}", stringMesssage);
            };

            channel.BasicConsume("message-test", true, consumer);
        }
    }
}
