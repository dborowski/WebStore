using System;
using WebStore.Messaging.Event;

namespace WebStore.Service.Event
{
    public class OrderRegisteredEvent : IOrderRegisteredEvent
    {
        public Guid Id { get; set; }
    }
}
