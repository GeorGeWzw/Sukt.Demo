using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sukt.RabbitMQSubscribe
{
    /// <summary>
    /// 死信队列测试消费者
    /// </summary>
    public class DeadLetterSubscribe
    {
        /// <summary>
        /// 消息消费者
        /// </summary>
        /// <returns></returns>
        public async Task Subscribe()
        {
            ConnectionFactory factory = new ConnectionFactory() 
            {
                HostName="192.168.0.166",
                UserName="test",
                Password="test",
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            while (true)
            {
                Thread.Sleep(2000);
            }
        }
    }
}
