using System;
using WebStore.Messaging.Command;
using WebStore.Web.Model;

namespace WebStore.Web.Messages
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
