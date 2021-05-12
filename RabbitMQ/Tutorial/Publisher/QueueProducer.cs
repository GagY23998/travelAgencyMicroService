using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Threading;

namespace TravelAgencyMicroService.rabbitmq
{

    public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            int count = 0;
            channel.QueueDeclare("demo-quueue",true,false,false,null);
                
            while(true){

                var message = new {Name = "Producer", Message=$"Hello count: {count}"};
                var encodedMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("","demo-queue",null,encodedMessage);
                count++;
                Thread.Sleep(1000);
            }

        }
    
    
    }


}
