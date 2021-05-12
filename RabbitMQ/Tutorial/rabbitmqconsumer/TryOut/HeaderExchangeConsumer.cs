using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbitmqconsumer
{
    public class HeaderExchangeConsumer
    {

        public static void Consume(IModel channel)
        {

            channel.ExchangeDeclare("demo-header-exchange", ExchangeType.Headers);
            channel.QueueDeclare("demo-header-queue", true, false, false, null);
        
            
            var header = new Dictionary<string, object>()
            {
                {"account","new" }
            };
            
            channel.QueueBind("demo-header-queue", "demo-header-exchange", string.Empty,header);
            channel.BasicQos(0, 10, false);

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);



            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var decodedMessage = Encoding.UTF8.GetString(body);
                System.Threading.Thread.Sleep(2000);
                System.Console.WriteLine(decodedMessage);
            };

            channel.BasicConsume("demo-header-queue", false, consumer);
            System.Console.WriteLine("Consumer started");
            System.Console.ReadLine();
        }
    }
}
