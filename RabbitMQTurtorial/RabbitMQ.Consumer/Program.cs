using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Models;
using System;
using System.Text;
using System.Threading;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Consumer 1 working");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SomeQueue1",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Worker worker = JsonConvert.DeserializeObject<Worker>(message);
                    Console.WriteLine($"WorkerName: {worker.NameSurname}{Environment.NewLine}WorkerDescritpion: {worker.WorkDescription}");
                };
                channel.BasicConsume(queue: "SomeQueue1",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
