using System;
using WebStore.Messaging.Command;
using WebStore.RabbitMq.Model;

namespace WebStore.RabbitMq.Messages
{
    public class ConfirmOrderCommand : IConfirmOrderCommand
    {
        private readonly Guid _id;

        public ConfirmOrderCommand(ConfirmOrderViewModel model)
        {
            _id = model.Id;
        }
        public Guid Id => _id;
    }
}
