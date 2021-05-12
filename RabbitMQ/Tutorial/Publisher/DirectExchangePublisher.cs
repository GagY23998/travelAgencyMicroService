using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;


namespace TravelAgencyMicroService.rabbitmq{

    public class DirectExchangePublisher
    {

        public static void Publish(IModel channel)
        {

            Dictionary<string,object> t11 = new System.Collections.Generic.Dictionary<string,object>(){
                {"x-message-tt1",30000}
            };

            channel.ExchangeDeclare("demo-direct-exchange",ExchangeType.Direct);
            int count =0;
            while(true){

                var message = new {Name = "Producer", Message=$"Hello count: {count}"};
                var encodedMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("demo-direct-exchange","account-init",null,encodedMessage);
                count++;
                System.Console.WriteLine(message);
                Thread.Sleep(2000);
            }


        }

    }


}