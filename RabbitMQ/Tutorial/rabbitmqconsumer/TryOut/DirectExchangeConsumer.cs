using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbitmqconsumer
{

    public static class DirectExchangeConsumer
    {

        public static void Consume(IModel channel){

            channel.ExchangeDeclare("demo-direct-exchange",ExchangeType.Direct);
            channel.QueueDeclare("demo-direct-queue",true,false,false,null);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.QueueBind("demo-direct-queue","demo-direct-exchange","account-init");
            channel.BasicQos(0,10,false);
            consumer.Received += (sender,e)=>{
                var body = e.Body.ToArray();
                var decodedMessage = Encoding.UTF8.GetString(body);
                System.Threading.Thread.Sleep(2000);
                System.Console.WriteLine(decodedMessage);
            };

            channel.BasicConsume("demo-direct-queue",false,consumer);
            System.Console.WriteLine("Consumer started");
            System.Console.ReadLine();
        }

    }


}