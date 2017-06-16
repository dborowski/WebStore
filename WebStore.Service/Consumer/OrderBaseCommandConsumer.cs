using MassTransit;
using System;
using System.Threading.Tasks;
using WebStore.Messaging.Command;

namespace WebStore.Service.Consumer
{
    public abstract class OrderBaseCommandConsumer<TMessage> : IConsumer<TMessage> where TMessage : class, IOrderCommand
    {
        public virtual async Task Consume(ConsumeContext<TMessage> context)
    {
        await Console.Out.WriteLineAsync($"Event {context.Message.GetType()} Id: {context.Message.Id}");
            
    }
}
}
