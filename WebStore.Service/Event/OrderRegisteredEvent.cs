using System;
using WebStore.Messaging.Event;
using WebStore.Messaging.RabbitMq;

namespace WebStore.Service.Event
{
    public class OrderRegisteredEvent : IOrderRegisteredEvent
    {
        private IRegisterOrderCommand command;
        private int id;
        
        public Guid Id { get; set; }
    }
}
