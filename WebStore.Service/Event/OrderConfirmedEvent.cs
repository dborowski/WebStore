using System;
using WebStore.Messaging.Event;

namespace WebStore.Service.Event
{
    public class OrderConfirmedEvent : IOrderConfirmedEvent
    {
        public Guid Id { get; set; }
    }
}
