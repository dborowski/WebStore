namespace WebStore.Messaging
{
    public class MassTransitConstant
    {
        public const string RabbitMqUri = "rabbitmq://localhost/webstore/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string OrderRegisteredQueue = "orderregistered.service";
        public const string OrderConfirmedQueue = "orderconfirmed.service";
        public const string OrderPayedQueue = "orderpayed.service";
        public const string OrderCompletedQueue = "ordercompleted.service";
        public const string OrderSagaQueue = "ordersaga.service";

        public const string OrderRegisteredNotificationQueue = "orderregistered.notification";
        public const string OrderConfirmedNotificationQueue = "orderconfirmed.notification";
        public const string OrderPayedNotificationQueue = "orderpayed.notification";
        public const string OrderCompletedNotificationQueue = "ordercompleted.notification";

    }
}
