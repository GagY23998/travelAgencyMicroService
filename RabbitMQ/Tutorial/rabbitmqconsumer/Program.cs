using System;
using RabbitMQ.Client;

namespace rabbitmqconsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){ Uri = new Uri("amqp://guest:guest@localhost:5672")};
            using var conn = factory.CreateConnection();
            using var channel = conn.CreateModel();
            channel.QueueDeclare("demo-header-queue",true,false,false,null);           

            FanoutExchangeConsumer.Consume(channel);
        }
    }
}
