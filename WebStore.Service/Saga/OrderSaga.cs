using Automatonymous;
using System;
using WebStore.Messaging.Command;
using WebStore.Service.Event;

namespace WebStore.Service.Saga
{
    public class OrderSaga : MassTransitStateMachine<OrderSagaState>
    {
        public State Registered { get; private set; }

        public State Confirmed { get; private set; }

        public State Payed { get; private set; }

        public State Completed { get; private set; }

        public Event<IRegisterOrderCommand> RegisterOrder { get; private set; }

        public Event<IConfirmOrderCommand> ConfirmOrder { get; private set; }

        public Event<IPayOrderCommand> PayOrder { get; private set; }

        public Event<ICompleteOrderCommand> CompleteOrder { get; private set; }

        public OrderSaga()
        {
            InstanceState(s => s.CurrentState);

            Event(() => RegisterOrder, x => x.CorrelateById(context => context.Message.Id));
            Event(() => ConfirmOrder, x => x.CorrelateById(context => context.Message.Id));
            Event(() => PayOrder, x => x.CorrelateById(context => context.Message.Id));
            Event(() => CompleteOrder, x => x.CorrelateById(context => context.Message.Id));

            Initially(
                When(RegisterOrder)
                    .Then(context =>
                    {
                        context.Instance.CorrelationId = context.Data.Id;
                        context.Instance.ReceivedDateTime = DateTime.Now;
                        context.Instance.CustomerId = context.Data.CustomerId;
                        context.Instance.Quantity = context.Data.Quantity;
                        context.Instance.ProductName = context.Data.ProductName;
                    })
                    .ThenAsync(
                        context => Console.Out.WriteLineAsync($"Order product {context.Data.ProductName} for customer {context.Data.CustomerId}" +
                            $" with id {context.Data.Id} registered"))
                    .TransitionTo(Registered)
                    .Publish(context => new OrderRegisteredEvent { Id = context.Instance.CorrelationId })
                );

            During(Registered,
                When(ConfirmOrder)
                    .Then(context => context.Instance.ConfirmationDateTime = DateTime.Now)
                    .ThenAsync(
                          context => Console.Out.WriteLineAsync($"Order product {context.Instance.ProductName} for customer {context.Instance.CustomerId}" +
                            $" with id {context.Instance.CorrelationId} confirmed"))
                    .TransitionTo(Confirmed)
                    .Publish(context => new OrderConfirmedEvent { Id = context.Instance.CorrelationId })
                );

            During(Confirmed,
                When(PayOrder)
                    .Then(context => context.Instance.PaymentDateTime = DateTime.Now)
                    .ThenAsync(
                          context => Console.Out.WriteLineAsync($"Order product {context.Instance.ProductName} for customer {context.Instance.CustomerId}" +
                            $" with id {context.Instance.CorrelationId} payed"))
                    .TransitionTo(Payed)
                    .Publish(context => new OrderPayedEvent { Id = context.Instance.CorrelationId })
                );
            During(Payed,
                When(CompleteOrder)
                    .Then(context => context.Instance.CompletedDateTime = DateTime.Now)
                    .ThenAsync(
                          context => Console.Out.WriteLineAsync($"Order product {context.Instance.ProductName} for customer {context.Instance.CustomerId}" +
                            $" with id {context.Instance.CorrelationId} completed"))
                    .Publish(context => new OrderCompletedEvent { Id = context.Instance.CorrelationId })
                    .Finalize()
                );

            SetCompletedWhenFinalized();
        }
    }
}
