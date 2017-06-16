using MassTransit;
using System;
using System.Threading.Tasks;
using WebStore.Messaging.Command;
using WebStore.Messaging.Event;
using WebStore.Service.Event;

namespace WebStore.Service.Consumer
{
    public class RegisterOrderCommandConsumer : OrderBaseCommandConsumer<IRegisterOrderCommand>
    {
        public override Task Consume(ConsumeContext<IRegisterOrderCommand> context)
        {
            context.Publish<IOrderRegisteredEvent>(new OrderRegisteredEvent { Id = context.Message.Id });
            return base.Consume(context);
        }
    }
}
