using RabbitMQ.Client;
using Sukt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sukt.RabbitMQPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    if (i % 7 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            DeadLetterPublish.Publish();
        }
    }
}

