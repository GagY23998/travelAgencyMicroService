using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TravelAgencyMicroService.rabbitmq
{

    public static class QueueConsumer{

        public static void Consume(IModel channel){

            channel.QueueDeclare("demo-queue",true,false,false,null);

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender,e)=>{
                var body = e.Body.ToArray();
                var decodedMessage = Encoding.UTF8.GetString(body);
                System.Console.WriteLine(decodedMessage);
            };

            channel.BasicConsume("demo-queue",false,consumer);
            System.Console.WriteLine("Consumer started");
        }

    }


}