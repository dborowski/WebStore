using MassTransit;
using WebStore.Messaging;
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
        public void RegisterOrder(RegisterOrderCommand registerOrderCommand)
        {
            _bus.Publish<IRegisterOrderCommand>(registerOrderCommand);
        }

        public void ListenToEvent<IOrderEvent>()
        {
            

        }
    }
}
