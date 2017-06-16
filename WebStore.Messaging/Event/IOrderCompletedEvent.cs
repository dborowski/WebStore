using System;
using WebStore.Messaging.Event;

namespace WebStore.Messaging.Event
{
    public interface IOrderCompletedEvent : IOrderEvent
    {
        Guid Id { get; set; }
    }
}