using MassTransit;
using System;
using System.Threading.Tasks;
using WebStore.Messaging.Event;

namespace WebStore.Notification.Consumer
{
    public abstract class OrderBaseEventConsumer<TMessage> : IConsumer<TMessage> where TMessage : class, IOrderEvent
    {
        public virtual async Task Consume(ConsumeContext<TMessage> context)
        {
            await Console.Out.WriteLineAsync($"Event {context.Message.GetType()} Id: {context.Message.Id}");
        }
    }
}
