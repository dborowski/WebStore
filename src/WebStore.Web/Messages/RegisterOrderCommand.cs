using System;
using WebStore.Messaging.Command;
using WebStore.Web.Model;

namespace WebStore.Web.Messages
{
    public class RegisterOrderCommand : IRegisterOrderCommand
    {
        private readonly OrderViewModel _orderViewModel;

        private readonly Guid _id;
        public RegisterOrderCommand(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
            _id = Guid.NewGuid();
        }

        public Guid Id => _id;
        public Guid CustomerId => _orderViewModel.CustomerId;

        public string ProductName => _orderViewModel.ProductName;

        public int Quantity => _orderViewModel.Quantity;

        public DateTime OrderDate => _orderViewModel.OrderDate;

    }
}
