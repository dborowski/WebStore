using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using WebStore.Messaging;
using WebStore.Messaging.Command;
using WebStore.RabbitMq.Messages;
using RegisterOrderCommand = WebStore.Messaging.RabbitMq.RegisterOrderCommand;

namespace WebStore.RabbitMq
{
    public class MassTransitManager
    {
        private readonly IBus _bus;
        public MassTransitManager()
        {
            _bus = MassTransitConfigurator.Configure();
        }
        
        public async Task ExecuteCommandOnOrder(IOrderCommand orderCommand)
        {
            var sendToUri = new Uri($"{MassTransitConstant.RabbitMqUri}{MassTransitConstant.OrderSagaQueue}");
            var endPoint = await _bus.GetSendEndpoint(sendToUri);
            await endPoint.Send(orderCommand, orderCommand.GetType());
        }
    }
}
