using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Models;
using System;
using System.Text;

namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            PublishMsgToSomeQueue1();
            PublishMsgToSomeQueue2();

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static void PublishMsgToSomeQueue1()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var worker = new Worker 
                {
                    NameSurname = "Matija Katadžić",
                    WorkDescription = "Developer"
                };

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(worker));

                channel.BasicPublish(exchange: "SomeExchangeName.SomeTopic",
                                     routingKey: "key1",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($"Sent ->{Environment.NewLine}WorkerName: {worker.NameSurname}{Environment.NewLine}WorkerDescritpion: {worker.WorkDescription}");

            }
        }
        private static void PublishMsgToSomeQueue2()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var worker = new Worker
                {
                    NameSurname = "Đemo Muhmedić",
                    WorkDescription = "Dobavljać"
                };

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(worker));

                channel.BasicPublish(exchange: "SomeExchangeName.SomeTopic",
                                     routingKey: "key2",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($"Sent ->{Environment.NewLine}WorkerName: {worker.NameSurname}{Environment.NewLine}WorkerDescritpion: {worker.WorkDescription}");
            }
        }
    }
}
