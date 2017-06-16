using MassTransit;
using System.Threading.Tasks;
using WebStore.Messaging.Command;
using WebStore.Messaging.Event;
using WebStore.Service.Event;

namespace WebStore.Service.Consumer
{
    public class CompleteOrderCommandConsumer : OrderBaseCommandConsumer<ICompleteOrderCommand>
    {
        public override Task Consume(ConsumeContext<ICompleteOrderCommand> context)
        {
            context.Publish<IOrderCompletedEvent>(new OrderCompletedEvent { Id = context.Message.Id });
            return base.Consume(context);
        }
    }
}
