using System;
using System.Text;
using Newtonsoft.Json;
using rabbitmq;
using RabbitMQ.Client;

namespace TravelAgencyMicroService.rabbitmq
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){ Uri = new Uri("amqp://guest:guest@localhost:5672")};
            using var conn = factory.CreateConnection();
            using var channel = conn.CreateModel();
            channel.QueueDeclare("demo-header-queue",true,false,false,null);       
            FanoutExchangePublisher.Publish(channel); 
            System.Console.WriteLine("chit started");

        }
    }
}

