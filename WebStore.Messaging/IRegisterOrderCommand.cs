using System;

namespace WebStore.Web.Messages
{
    public interface IRegisterOrderCommand
    {
        Guid CustomerId { get; }
        DateTime OrderDate { get; }
        string ProductName { get; }
        int Quantity { get; }
    }
}