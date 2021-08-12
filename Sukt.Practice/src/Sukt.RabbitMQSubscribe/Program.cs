using System;

namespace Sukt.RabbitMQSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length>0)
            {
                Console.WriteLine($"消费者：{args[0]}启动");
            }
            Task.Factory.StartNew(() => DeadLetterSubscribe.Subscribe());
            Task.Factory.StartNew(() => BusinessQueueSubscribe.Subscribe());
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
