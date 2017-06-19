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
            //OrderSageRun();
            RabbitMqRun();
        }

        private static void RabbitMqRun()
        {
            Console.Title = "Registration service";
            using (var rabbitMqManager = new RabbitMqManager())
            {
                rabbitMqManager.ListenForRegisterOrderCommand();
                Console.WriteLine("Listening for RegisterOrderCommand..");
                Console.ReadKey();
            }
        }

        private static void OrderSageRun()
        {
            var saga = new OrderSaga();
            var repo = new InMemorySagaRepository<OrderSagaState>();

            var bus = MassTransitConfigurator.Configure((conf, host) =>
            {
                conf.ReceiveEndpoint(host, MassTransitConstant.OrderSagaQueue,
                    cfg => { cfg.StateMachineSaga(saga, repo); });
            });

            bus.Start();


            Console.WriteLine("Listening for Order events.. Press enter to exit");
            Console.ReadLine();
            bus.Stop();
        }
    }
}
