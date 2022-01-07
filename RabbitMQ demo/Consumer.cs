using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ_demo
{
    internal class Consumer
    {
        EventingBasicConsumer consumer;
        IConnection connection;
        IModel channel;
        public EventingBasicConsumer Consume()
        {
            ConnectionFactory rmqFactory = new ConnectionFactory
            {
                HostName = "localhost",
                VirtualHost = "vhost1",
                UserName = "guest",
                Password = "guest"
            };
            connection = rmqFactory.CreateConnection("testConnection");
            channel = connection.CreateModel();

            channel.ExchangeDeclare("exchange1", "direct", true, false, null);
            channel.QueueBind("queue1", "exchange1", "rounting1", null);
            consumer = new EventingBasicConsumer(channel);
            consumer.Received += (o, e) =>
            {
                string stringContent = Encoding.UTF8.GetString(e.Body.ToArray());
                TestMessage message = JsonConvert.DeserializeObject<TestMessage>(stringContent);
                Console.WriteLine("Message received:\n" + message.Content);
            };
            channel.BasicConsume("queue1", true, consumer);
            return consumer;
        }
    }
}
