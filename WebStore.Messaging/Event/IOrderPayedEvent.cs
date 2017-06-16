using System;

namespace WebStore.Messaging.Event
{
    public interface IOrderPayedEvent : IOrderEvent
    {
        Guid Id { get; set; }
    }
}