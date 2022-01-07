using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ_demo
{
    internal class Publisher
    {
        public bool PlaceSmsMessageToQueue(TestMessage message)
        {
            bool retVal = false;
            try
            {
                ConnectionFactory rmqFactory = new ConnectionFactory
                {
                    HostName = "localhost",
                    VirtualHost = "vhost1",
                    UserName = "guest",
                    Password = "guest"
                };
                using (IConnection connection = rmqFactory.CreateConnection("testConnection"))
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare("exchange1", "direct", true, false, null);
                        channel.QueueBind("queue1", "exchange1", "rounting1", null);
                        var stringContent = JsonConvert.SerializeObject(message);
                        byte[] contents = Encoding.UTF8.GetBytes(stringContent);
                        channel.BasicPublish("exchange1", "rounting1", null, contents);
                    }
                }
                retVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }
    }
}
