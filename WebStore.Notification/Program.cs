using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using WebStore.Messaging;
using WebStore.Notification.Consumer;

namespace WebStore.Notification
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = MassTransitConfigurator.Configure(ListenToEvents);

            bus.Start();

            Console.WriteLine("Listening for Order events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }

        static void ListenToEvents(IRabbitMqBusFactoryConfigurator configurator, IRabbitMqHost host)
        {
            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderRegisteredNotificationQueue, cfg =>
            {
                cfg.Consumer<OrderRegisteredEventConsumer>();
            });

            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderConfirmedNotificationQueue, cfg =>
            {
                cfg.Consumer<OrderConfirmedEventConsumer>();
            });

            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderPayedNotificationQueue, cfg =>
            {
                cfg.Consumer<OrderPayedEventConsumer>();
            });

            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderCompletedNotificationQueue, cfg =>
            {
                cfg.Consumer<OrderCompletedEventConsumer>();
            });
        }
    }
}
