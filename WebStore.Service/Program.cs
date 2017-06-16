using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using WebStore.Messaging;
using WebStore.Service.Consumer;

namespace WebStore.Service
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
            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderRegisteredQueue, cfg =>
            {
                cfg.Consumer<RegisterOrderCommandConsumer>();
            });

            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderConfirmedQueue, cfg =>
            {
                cfg.Consumer<ConfirmOrderCommandConsumer>();
            });

            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderPayedQueue, cfg =>
            {
                cfg.Consumer<PayOrderCommandConsumer>();
            });

            configurator.ReceiveEndpoint(host, MassTransitConstant.OrderCompletedQueue, cfg =>
            {
                cfg.Consumer<CompleteOrderCommandConsumer>();
            });
        }
    }
}
