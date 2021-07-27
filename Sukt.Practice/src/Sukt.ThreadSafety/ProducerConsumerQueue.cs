using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sukt.ThreadSafety
{
    public class ProducerConsumerQueue : IDisposable
    {
        /// <summary>
        /// 创建自复位事件
        /// </summary>
        EventWaitHandle wh = new AutoResetEvent(false);
        //生命一个string类型的队列
        Queue<string> queues = new Queue<string>();
        //创建一个线程
        Thread worker;
        readonly object _locker = new object();
        public ProducerConsumerQueue()
        {
            worker = new Thread(Work);//开启一个线程执行方法
            worker.Start();
        }
        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="message"></param>
        public void EnqueueTask(string message)
        {
            lock (_locker)
            {
                queues.Enqueue(message);//向队列内添加消息
            }
            wh.Set();//写入数据之后通知处理者
        }
        /// <summary>
        /// 工作方法
        /// </summary>
        public void Work()
        {
            while (true)
            {
                string message = null;
                lock (_locker)
                {
                    if (queues.Count > 0)
                    {
                        message = queues.Dequeue();
                        if(message==null)
                        {
                            return;
                        }
                    }
                    if(message!=null)
                    {
                        Console.WriteLine($"正在处理：{message}");
                        Thread.Sleep(1000);//模拟工作
                    }
                    else
                    {
                        //阻止当前线程并等待信号
                        wh.WaitOne();
                    }
                }
            }
        }
        public void Dispose()
        {
            EnqueueTask(null);
            worker.Join();//阻塞线程，并等待线程结束
            wh.Close();
        }
    }
}
