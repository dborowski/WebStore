using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Web.Model;

namespace WebStore.Web.Messages
{
    public class RegisterOrderCommand : IRegisterOrderCommand
    {
        private readonly OrderViewModel _orderViewModel;
        public RegisterOrderCommand(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
        }

        public Guid CustomerId => _orderViewModel.CustomerId;

        public string ProductName => _orderViewModel.ProductName;

        public int Quantity => _orderViewModel.Quantity;

        public DateTime OrderDate => _orderViewModel.OrderDate;
    }
}
