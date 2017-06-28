using Microsoft.AspNetCore.Mvc;
using WebStore.RabbitMq.Messages;
using WebStore.RabbitMq.Model;

namespace WebStore.RabbitMq.Controllers
{
    public class RegisterOrderController : BaseOrderController<OrderViewModel, RegisterOrderCommand>
    {
        public RegisterOrderController(MassTransitManager massTransitManager) : base(massTransitManager)
        {
        }
        public IActionResult RegisterOrder()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegisterOrder(OrderViewModel model)
        {
            Post(model);
            return View("Thanks");
        }
    }
}
