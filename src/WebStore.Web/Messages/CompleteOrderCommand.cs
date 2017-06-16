using System;
using WebStore.Messaging.Command;
using WebStore.Web.Model;

namespace WebStore.Web.Messages
{
    public class CompleteOrderCommand : ICompleteOrderCommand
    {
        private readonly Guid _id;

        public CompleteOrderCommand(CompleteOrderViewModel model)
        {
            _id = model.Id;
        }
        public Guid Id => _id;
    }
}
