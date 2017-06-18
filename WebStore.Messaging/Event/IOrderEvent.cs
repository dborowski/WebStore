using System;

namespace WebStore.Messaging.Event
{
    public interface IOrderEvent
    {
        Guid Id { get; set; }
    }
}
