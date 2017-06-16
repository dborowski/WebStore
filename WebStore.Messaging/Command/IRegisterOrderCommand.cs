using System;

namespace WebStore.Messaging.Command
{
    public interface IRegisterOrderCommand : IOrderCommand
    {
        Guid CustomerId { get; }
        DateTime OrderDate { get; }
        string ProductName { get; }
        int Quantity { get; }
    }
}