using RabbitMQ.Client;
using Sukt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sukt.RabbitMQPublish
{
    public class DeadLetterPublish
    {
        /// <summary>
        /// 死信交换机队列配置
        /// </summary>
        /// <returns></returns>
        public static void Publish()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "192.168.31.188",
                UserName = "guest",
                Password = "guest",
                Port=30104
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //#region 死信队列配置
            ////Exchange 声明交换机
            //channel.ExchangeDeclare(
            //    exchange: RabbitMQExchangeConstans.DeadLetterExchangeName,//交换机名称
            //    type: ExchangeType.Fanout,//Exchange有三种类型分别是：
            //                   //fanout:把所有发送到该Exchange的消息投递到所有与它绑定的队列中。
            //                   //direct:把消息投递到那些binding key与routing key完全匹配的队列中。
            //                   //topic:将消息路由到binding key与routing key模式匹配的队列中。
            //    durable: true,//消息是否持久
            //    autoDelete: false//是否在最后一个订阅者取消订阅时自动删除
            //    );
            ////声明队列
            //channel.QueueDeclare(
            //    queue: RabbitMQExchangeConstans.DeadLetterQueueName,
            //    durable: true,//是否持久
            //    exclusive: false, //是否在链接关闭时删除
            //    autoDelete: false//是否在最后一个订阅者取消订阅时自动删除
            //    );
            ////队列绑定交换机
            //channel.QueueBind(
            //    queue: RabbitMQExchangeConstans.DeadLetterQueueName,//队列名称
            //    exchange: RabbitMQExchangeConstans.DeadLetterExchangeName,//交换机名称
            //    routingKey: RabbitMQExchangeConstans.DeadLetterRouteName//路由名称
            //    );
            //#endregion
            //#region 正常业务队列配置
            ////Exchange 声明交换机
            //channel.ExchangeDeclare(
            //    exchange: RabbitMQExchangeConstans.BusinessExchangeName,//交换机名称
            //    type: "fanout",//
            //    durable: true,//消息是否持久
            //    autoDelete: false//是否在最后一个订阅者取消订阅时自动删除
            //    );
            ////声明队列
            //channel.QueueDeclare(
            //    queue: RabbitMQExchangeConstans.BusinessQueueName,
            //    durable: true,//是否持久
            //    exclusive: false, //是否在链接关闭时删除
            //    autoDelete: false,//是否在最后一个订阅者取消订阅时自动删除
            //    arguments: new Dictionary<string, object>
            //    {
            //        { "x-dead-letter-exchange",RabbitMQExchangeConstans.DeadLetterExchangeName},//设置当前队列的死信交换机
            //        {"x-dead-letter-routing-key",RabbitMQExchangeConstans.DeadLetterRouteName },//设置当前交换机的路由key，DLX(死信交换机)根据该值去找死信消息存放的队列，
            //        //{"x-message-ttl",10000 }//设置消息存活的时间
            //    });
            ////队列绑定交换机
            //channel.QueueBind(
            //    queue: RabbitMQExchangeConstans.BusinessQueueName,//队列名称
            //    exchange: RabbitMQExchangeConstans.BusinessExchangeName,//交换机名称
            //    routingKey: RabbitMQExchangeConstans.BusinessRouteName//路由名称
            //    );

            ////创建基本属性
            //var properties = channel.CreateBasicProperties();
            //properties.Persistent = true;
            //string msg;
            ////do
            ////{
            ////    msg = Console.ReadLine();
            ////    channel.BasicPublish(
            ////    exchange: RabbitMQExchangeConstans.BusinessExchangeName,//发送消息的队列
            ////    routingKey: RabbitMQExchangeConstans.BusinessRouteName,//路由名称
            ////    basicProperties: properties,//基础属性
            ////    body: Encoding.UTF8.GetBytes(msg)
            ////    );
            ////} while (!msg.Trim().ToLower().Equals("exit"));
            //for (int i = 0; i < 1000; i++)
            //{
            //    if (i % 7 != 0)
            //    {
            //        msg = $"我是一个小草{i}";
            //    }
            //    else
            //    {
            //        msg = $"行吧！你是对的。{i}";
            //    }
            //    //msg = Console.ReadLine();
            //    channel.BasicPublish(
            //    exchange: RabbitMQExchangeConstans.BusinessExchangeName,//发送消息的队列
            //    routingKey: RabbitMQExchangeConstans.BusinessRouteName,//路由名称
            //    basicProperties: properties,//基础属性
            //    body: Encoding.UTF8.GetBytes(msg)
            //    );
            //}



            //#endregion

            #region 正常业务队列配置
            //Exchange 声明交换机
            channel.ExchangeDeclare(
                exchange: "test",//交换机名称
                type: "topic",//
                durable: true,//消息是否持久
                autoDelete: false//是否在最后一个订阅者取消订阅时自动删除
                );
            //声明队列
            channel.QueueDeclare(
                queue: "woshibaba",
                durable: true,//是否持久
                exclusive: false, //是否在链接关闭时删除
                autoDelete: false//是否在最后一个订阅者取消订阅时自动删除
                );
            //队列绑定交换机
            channel.QueueBind(
                queue: "woshibaba",//队列名称
                exchange: "test",//交换机名称
                routingKey: "testname"//路由名称
                );

            //创建基本属性
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            string msg;
            //do
            //{
            //    msg = Console.ReadLine();
            //    channel.BasicPublish(
            //    exchange: RabbitMQExchangeConstans.BusinessExchangeName,//发送消息的队列
            //    routingKey: RabbitMQExchangeConstans.BusinessRouteName,//路由名称
            //    basicProperties: properties,//基础属性
            //    body: Encoding.UTF8.GetBytes(msg)
            //    );
            //} while (!msg.Trim().ToLower().Equals("exit"));
            for (int i = 0; i < 1000; i++)
            {
                if (i % 7 != 0)
                {
                    msg = $"我是一个小草{i}";
                }
                else
                {
                    msg = $"行吧！你是对的。{i}";
                }
                //msg = Console.ReadLine();
                channel.BasicPublish(
                exchange: "test",//发送消息的队列
                routingKey: "testname",//路由名称
                basicProperties: properties,//基础属性
                body: Encoding.UTF8.GetBytes(msg)
                );
            }



            #endregion
        }

    }
}