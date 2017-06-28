using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using WebStore.Messaging;
using WebStore.Messaging.RabbitMq;
using WebStore.Service.Event;

namespace WebStore.Service.Consumer.RabbitMQ
{
    public class RegisteredOrderCommandConsumer : DefaultBasicConsumer
    {
        private readonly RabbitMqManager _rabbitMqManager;

        public RegisteredOrderCommandConsumer(
            RabbitMqManager rabbitMqManager)
        {
            this._rabbitMqManager = rabbitMqManager;
        }

        public override void HandleBasicDeliver(
            string consumerTag, ulong deliveryTag,
            bool redelivered, string exchange, string routingKey,
            IBasicProperties properties, byte[] body)
        {
            if (properties.ContentType != RabbitMqConstants.JsonMimeType)
                throw new ArgumentException(
                    $"Can't handle content type {properties.ContentType}");

            var message = Encoding.UTF8.GetString(body);
            var commandObj =
                JsonConvert.DeserializeObject<RegisterOrderReceiveCommand>(
                    message);
            Consume(commandObj);
            _rabbitMqManager.SendAck(deliveryTag);
        }

        private void Consume(IRegisterOrderCommand command)
        {
            //Store order registration and get Id
            var id = Guid.NewGuid();
            Console.WriteLine($"Order with id {id} registered");
            Console.WriteLine("Publishing order registered event");

            //notify subscribers that a order is registered
            var orderRegisteredEvent = new RabbitMqOrderRegisteredEvent(command, id);
            //publish event
            _rabbitMqManager.SendOrderRegisteredEvent(orderRegisteredEvent);
        }
    }
}
