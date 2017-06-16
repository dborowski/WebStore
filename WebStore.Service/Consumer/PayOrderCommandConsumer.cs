using MassTransit;
using System.Threading.Tasks;
using WebStore.Messaging.Command;
using WebStore.Messaging.Event;
using WebStore.Service.Event;

namespace WebStore.Service.Consumer
{
    public class PayOrderCommandConsumer : OrderBaseCommandConsumer<IPayOrderCommand>
    {
        public override Task Consume(ConsumeContext<IPayOrderCommand> context)
        {
            context.Publish<IOrderPayedEvent>(new OrderPayedEvent { Id = context.Message.Id });
            return base.Consume(context);
        }
    }
}
