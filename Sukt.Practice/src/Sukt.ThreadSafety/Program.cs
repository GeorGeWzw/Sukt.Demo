using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sukt.ThreadSafety
{
    class Program
    {

        static int i = 2;
        AutoResetEvent AutoResetEvent = new AutoResetEvent(false);
        static  void Main(string[] args)
        {
            //using var queue = new ProducerConsumerQueue();
            //queue.EnqueueTask("芭比开始工作！！！！！！！！");
            //for (int i = 0; i < 32; i++)
            //{
            //    queue.EnqueueTask($"A897545----{i}开始工作");
            //}
            //queue.EnqueueTask("啦啦开始工作！！！！！！！");

            Console.WriteLine("Hello World!");
            //continuation
            // Task.WhenAll().ContinueWith(o=>o.)
            List<Task> list = new List<Task>();
            for (int a = 0; a < 20; a++)
            {
                list.Add(Task.Run(()=> {

                    Add(); Sum();
                }));
                
            }
            Task.WaitAll(list.ToArray());
            Console.ReadKey();
        }

 
        public static void Add()
        {
            //使用原子性  Interlocked来操作一个数字的  ++或者--
            Interlocked.Increment(ref i);
            Console.WriteLine($"执行了++{i}");

        }
        public static void Sum()
        {
            Interlocked.Decrement(ref i);
            Console.WriteLine($"执行了--{i}");
         
        }
    }

}
