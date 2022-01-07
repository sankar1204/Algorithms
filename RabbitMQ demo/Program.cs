using System;

namespace RabbitMQ_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Consumer consumer = new Consumer();
            consumer.Consume();

            Console.WriteLine("welcome to rabbit mq demo");
            while (true)
            {
                Console.WriteLine("Enter the message you want to send");
                string content = Console.ReadLine();
                publisher.PlaceSmsMessageToQueue(new TestMessage { Content = content });
            }
        }
    }
}
