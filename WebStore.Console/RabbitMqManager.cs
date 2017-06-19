using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WebStore.Messaging;
using WebStore.Messaging.RabbitMq;

namespace WebStore.Console
{
    public class RabbitMqManager : IDisposable
    {
        private readonly IModel _channel;

        public RabbitMqManager()
        {
            var connectionFactory = new ConnectionFactory { Uri = RabbitMqConstants.RabbitMqUri };
            var connection = connectionFactory.CreateConnection();
            _channel = connection.CreateModel();
            connection.AutoClose = true;
            _channel.ExchangeDeclare(
                exchange: RabbitMqConstants.RegisterOrderExchange,
                type: ExchangeType.Direct);
            _channel.QueueDeclare(
                queue: RabbitMqConstants.RegisterOrderQueue, durable: false,
                exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(
                queue: RabbitMqConstants.RegisterOrderQueue,
                exchange: RabbitMqConstants.RegisterOrderExchange,
                routingKey: "");

        }

        public void SendRegisterOrderCommand(IRegisterOrderCommand command)
        {
            var serializedCommand = JsonConvert.SerializeObject(command);

            var messageProperties = _channel.CreateBasicProperties();
            messageProperties.ContentType =
                RabbitMqConstants.JsonMimeType;

            _channel.BasicPublish(
                exchange: RabbitMqConstants.RegisterOrderExchange,
                routingKey: "",
                basicProperties: messageProperties,
                body: Encoding.UTF8.GetBytes(serializedCommand));
        }


        public void Dispose()
        {
            if (!_channel.IsClosed)
                _channel.Close();
        }
    }
}