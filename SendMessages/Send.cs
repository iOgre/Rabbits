using System;
using System.Text;
using RabbitMQ.Client;

namespace SendMessages
{
    public class Send
    {
        public Send()
        {
            
        }
        public string Act(string message = "Hello Rabbit")
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
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
                    return message;

                }
            }
        }
    }
}