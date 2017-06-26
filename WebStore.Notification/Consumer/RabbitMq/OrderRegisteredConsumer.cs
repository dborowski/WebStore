using System;
using WebStore.Messaging.Event;

namespace WebStore.Notification.Consumer.RabbitMq
{
    public class OrderRegisteredConsumer
    {
        public void Consume(IRabbitMqOrderRegisteredEvent registeredEvent)
        {
            //Send notification to user
            Console.WriteLine($"Customer notification sent: Order id {registeredEvent.Id} registered");
        }
    }
}