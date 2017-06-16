using System.Threading.Tasks;
using MassTransit;
using WebStore.Messaging.Command;
using WebStore.Messaging.Event;
using WebStore.Service.Event;

namespace WebStore.Service.Consumer
{
    public class ConfirmOrderCommandConsumer : OrderBaseCommandConsumer<IConfirmOrderCommand>
    {
        public override Task Consume(ConsumeContext<IConfirmOrderCommand> context)
        {
            context.Publish<IOrderConfirmedEvent>(new OrderConfirmedEvent { Id = context.Message.Id });
            return base.Consume(context);
        }
    }
}
