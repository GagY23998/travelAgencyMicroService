using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbitmqconsumer
{
    public class FanoutExchangeConsumer
    {

        public static void Consume(IModel channel)
        {

            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout);
            channel.QueueDeclare("demo-fanout-queue", true, false, false, null);


            var header = new Dictionary<string, object>()
            {
                {"account","new" }
            };

            channel.QueueBind("demo-fanout-queue", "demo-fanout-exchange", string.Empty);
            channel.BasicQos(0, 10, false);

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);



            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var decodedMessage = Encoding.UTF8.GetString(body);
                System.Threading.Thread.Sleep(2000);
                System.Console.WriteLine(decodedMessage);
            };

            channel.BasicConsume("demo-fanout-queue", false, consumer);
            System.Console.WriteLine("Consumer started");
            System.Console.ReadLine();
        }

    }
}
