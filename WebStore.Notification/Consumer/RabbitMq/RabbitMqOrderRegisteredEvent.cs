using System;
using WebStore.Messaging.Event;
using WebStore.Messaging.RabbitMq;

namespace WebStore.Notification.Consumer.RabbitMq
{
    public class RabbitMqOrderRegisteredEvent : IRabbitMqOrderRegisteredEvent
    {
        private IRegisterOrderCommand command;
        private int orderId;
        public RabbitMqOrderRegisteredEvent(IRegisterOrderCommand command, int orderId)
        {
            this.command = command;
            this.orderId = orderId;
        }
        public int OrderId => orderId;
        public string PickupName => command.PickupName;
        public string PickupAddress => command.PickupAddress;
        public string PickupCity => command.PickupCity;

        public string DeliverName => command.DeliverName;
        public string DeliverAddress => command.DeliverAddress;
        public string DeliverCity => command.DeliverCity;

        public int Weight => command.Weight;
        public bool Fragile => command.Fragile;
        public bool Oversized => command.Oversized;
        public Guid Id { get; set; }
    }
}
