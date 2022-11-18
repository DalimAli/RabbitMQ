using RabbitMQ.Client;

namespace RabbitMq.Publisher.Exchanges
{
    public class FanoutExchange
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
            var queueName = channel.QueueDeclare().QueueName;


        }
    }
}
