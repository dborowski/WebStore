using MassTransit;
using System;

namespace WebStore.Messaging
{
    public class MassTransitConfigurator
    {
        public const string RabbitMqUri = "rabbitmq://localhost/webstore/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public static IBus Configure()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri(RabbitMqUri), h =>
                {
                    h.Username(UserName);
                    h.Password(Password);
                });
            });

            return bus;

        }
    }
}
