using System;

namespace WebStore.Messaging.Event
{
    public interface IOrderRegisteredEvent : IOrderEvent
    {
        Guid Id { get; set; }
    }
}