using System;

namespace WebStore.Messaging.Command
{
    public interface IOrderCommand
    {
        Guid Id { get; }
    }
}
