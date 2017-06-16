using System;
using WebStore.Messaging.Command;
using WebStore.Web.Model;

namespace WebStore.Web.Messages
{
    public class PayOrderCommand : IPayOrderCommand
    {
        private readonly Guid _id;

        public PayOrderCommand(PayOrderViewModel model)
        {
            _id = model.Id;
        }
        public Guid Id => _id;
    }
}
