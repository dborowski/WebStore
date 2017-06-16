using System;
using WebStore.Messaging.Event;

namespace WebStore.Service.Event
{
    public class OrderCompletedEvent : IOrderCompletedEvent
    {
        public Guid Id { get; set; }
    }
}
