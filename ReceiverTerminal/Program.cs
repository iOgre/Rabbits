using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ReceiverTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Receiver!");
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "hello",
                        durable: false,
                        exclusive: false,
                        arguments: null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(message);

                    };
                    channel.BasicConsume(
                        queue: "hello",
                        autoAck: true,
                        consumer: consumer );
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        
        public void Act()
        {
          
        }
    }
}