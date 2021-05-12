using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbitmqconsumer
{

    public static class TopicExchangeConsumer
    {

        public static void Consume(IModel channel){

            channel.ExchangeDeclare("demo-topic-exchange",ExchangeType.Topic);
            channel.QueueDeclare("demo-topic-queue",true,false,false,null);
            channel.QueueBind("demo-topic-queue","demo-topic-exchange","account.*");
            channel.BasicQos(0,10,false);
         
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
         
            consumer.Received += (sender,e)=>{
                var body = e.Body.ToArray();
                var decodedMessage = Encoding.UTF8.GetString(body);
                System.Threading.Thread.Sleep(2000);
                System.Console.WriteLine(decodedMessage);
            };

            channel.BasicConsume("demo-topic-queue",false,consumer);
            System.Console.WriteLine("Consumer started");
            System.Console.ReadLine();
        }

    }


}