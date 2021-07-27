using System;

namespace Sukt.Common
{
    /// <summary>
    /// RabbitMQExchange 名称定义
    /// </summary>
    public class RabbitMQExchangeConstans
    {
        #region 死信队列静态字段定义
        /// <summary>
        /// 死信Exchange
        /// </summary>
        public const string DeadLetterExchangeName = "sukt.deadletter.exchange";
        /// <summary>
        /// 死信路由名称
        /// </summary>
        public const string DeadLetterRouteName = "sukt.deadletter.route";
        /// <summary>
        /// 死信队列名称
        /// </summary>
        public const string DeadLetterQueueName = "sukt.deadletter.queue";
        #endregion

        #region 业务队列静态字段定义
        /// <summary>
        /// 业务Exchange
        /// </summary>
        public const string BusinessExchangeName = "sukt.business.exchange";
        /// <summary>
        /// 业务路由队列名称
        /// </summary>
        public const string BusinessRouteName = "sukt.business.route";
        /// <summary>
        /// 业务队列名称
        /// </summary>
        public const string BusinessQueueName = "sukt.business.queue";
        #endregion
    }
}
