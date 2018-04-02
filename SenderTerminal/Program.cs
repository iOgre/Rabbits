using System;
using System.Text;
using RabbitMQ.Client;
using SendMessages;

namespace SenderTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sender!");
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
            var message = "hello rabbit";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue:"hello",
                        durable:false,
                        autoDelete:false,
                        arguments : null
                    );
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "hello",
                        basicProperties : null,
                        body : body
                    );
                    //return message;

                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}