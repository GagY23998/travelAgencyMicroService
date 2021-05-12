using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;



namespace rabbitmq
{
    public class FanoutExchangePublisher
    {

        public static void Publish(IModel channel)
        {

            Dictionary<string, object> t11 = new System.Collections.Generic.Dictionary<string, object>(){
                    {"x-message-tt1",30000}
                };

            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout, arguments: t11);
            int count = 0;
            while (true)
            {

                var message = new { Name = "Producer", Message = $"Hello from topic exchange, count: {count}" };
                var encodedMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
             
                channel.BasicPublish("demo-fanout-exchange", string.Empty, null, encodedMessage);
                count++;
                System.Console.WriteLine(message);
                Thread.Sleep(2000);
            }
        }
    }
}
