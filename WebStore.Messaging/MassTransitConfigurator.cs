using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace WebStore.Messaging
{
    public class MassTransitConfigurator
    {
        public static IBusControl Configure(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registerAction = null)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri(MassTransitConstant.RabbitMqUri), h =>
                {
                    h.Username(MassTransitConstant.UserName);
                    h.Password(MassTransitConstant.Password);
                });

                registerAction?.Invoke(x, host);
            });
            
            return bus;

        }
    }
}
