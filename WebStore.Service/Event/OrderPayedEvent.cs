using System;
using WebStore.Messaging.Event;

namespace WebStore.Service.Event
{
    public class OrderPayedEvent : IOrderPayedEvent
    {
        public Guid Id { get; set; }
    }
}
