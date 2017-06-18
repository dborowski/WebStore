using Automatonymous;
using MassTransit;
using MassTransit.Saga;
using System;
using WebStore.Messaging;
using WebStore.Service.Saga;

namespace WebStore.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var saga = new OrderSaga();
            var repo = new InMemorySagaRepository<OrderSagaState>();

            var bus = MassTransitConfigurator.Configure((conf, host) =>
            {
                conf.ReceiveEndpoint(host, MassTransitConstant.OrderSagaQueue, cfg =>
                {
                    cfg.StateMachineSaga(saga, repo);
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Order events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
