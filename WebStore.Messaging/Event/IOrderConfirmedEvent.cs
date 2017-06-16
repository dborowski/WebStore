using System;

namespace WebStore.Messaging.Event
{
    public interface IOrderConfirmedEvent : IOrderEvent
    {
        Guid Id { get; set; }
    }
}