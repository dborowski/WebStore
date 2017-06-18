using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Messaging;
using WebStore.Messaging.Command;
using WebStore.Web.Messages;

namespace WebStore.Web
{
    public class MassTransitManager
    {
        private readonly IBus _bus;
        public MassTransitManager()
        {
            _bus = MassTransitConfigurator.Configure();
        }

        private Dictionary<Type, string> _commandQueueMap = new Dictionary<Type, string> {
            {typeof(RegisterOrderCommand), MassTransitConstant.OrderRegisteredQueue},
            {typeof(ConfirmOrderCommand), MassTransitConstant.OrderConfirmedQueue},
            {typeof(PayOrderCommand), MassTransitConstant.OrderPayedQueue},
            {typeof(CompleteOrderCommand), MassTransitConstant.OrderCompletedQueue}
        };

        public async Task ExecuteCommandOnOrder(IOrderCommand orderCommand)
        {
            var sendToUri = new Uri($"{MassTransitConstant.RabbitMqUri}" + $"{MassTransitConstant.OrderSagaQueue}");
            var endPoint = await _bus.GetSendEndpoint(sendToUri);
            await endPoint.Send(orderCommand, orderCommand.GetType());
        }
    }
}
