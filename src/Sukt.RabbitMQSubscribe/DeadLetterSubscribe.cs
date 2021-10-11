using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sukt.Common;
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
        public static void Subscribe()
        {
            Console.WriteLine($"业务消息成为死信之后死信队列消费者");
            //创建连接工厂
            var factory = new ConnectionFactory
            {
                HostName = "192.168.0.166",
                UserName = "guest",
                Password = "guest",
                AutomaticRecoveryEnabled = true,
                TopologyRecoveryEnabled = true
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //接收到的消息处理事件
            EventingBasicConsumer Recipient = new EventingBasicConsumer(channel);
            Recipient.Received += (ch, ea) =>
            {
                var RecipientMsg = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine($"死信队列收到消息并处理完成：{RecipientMsg}");
                // 确认该消息已被处理
                channel.BasicAck(ea.DeliveryTag, false);
            };
            channel.BasicConsume(RabbitMQExchangeConstans.DeadLetterQueueName, false, Recipient);
            Console.WriteLine("后台处理方法已启动");
            while (true)
            {
                Thread.Sleep(2000);
            }
        }
    }
}
