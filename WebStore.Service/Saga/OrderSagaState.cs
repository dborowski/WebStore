using Automatonymous;
using System;

namespace WebStore.Service.Saga
{
    public class OrderSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public Guid CustomerId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceivedDateTime  { get; set; }
        public DateTime? RegistrationDateTime { get; set; }

        public DateTime? ConfirmationDateTime { get; set; }

        public DateTime? PaymentDateTime { get; set; }

        public DateTime? CompletedDateTime { get; set; }

        public State CurrentState { get; set; }
    }
}
