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
    public class BusinessQueueSubscribe
    {
        /// <summary>
        /// 业务消息消费者
        /// </summary>
        /// <returns></returns>
        public static void Subscribe()
        {
            Console.WriteLine($"业务消息消费者启动");
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
                if (RecipientMsg.Contains("你是对的"))//如果包含条件则进入死信交换队列
                {
                    Console.WriteLine("消息投递到死信队列：");
                    channel.BasicNack(ea.DeliveryTag, false, false);
                }
                else
                {
                    // 确认该消息已被处理
                    Console.WriteLine($"业务队列收到消息并处理：{RecipientMsg}");
                    channel.BasicAck(ea.DeliveryTag, false);
                }
            };
            channel.BasicConsume(RabbitMQExchangeConstans.BusinessQueueName, false, Recipient);
            Console.WriteLine("后台处理方法已启动");
            while (true)
            {
                Thread.Sleep(2000);
            }
        }
    }
}
