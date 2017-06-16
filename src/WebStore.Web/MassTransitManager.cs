using MassTransit;
using System;
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
        public async Task RegisterOrder(RegisterOrderCommand registerOrderCommand)
        {
            var sendToUri = new Uri($"{MassTransitConstant.RabbitMqUri}" + $"{MassTransitConstant.OrderRegisteredQueue}");
            var endPoint = await _bus.GetSendEndpoint(sendToUri);
            await endPoint.Send<IRegisterOrderCommand>(registerOrderCommand);
        }
    }
}
