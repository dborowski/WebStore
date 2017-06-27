using Microsoft.AspNetCore.Mvc;
using WebStore.Messaging.RabbitMq;

namespace WebStore.RabbitMq.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult RegisterOrder()
        {
            return View();
        }

        public IActionResult Stuff()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterOrder(OrderViewModel model)
        {
            var registerOrderCommand = new RegisterOrderCommand(model);

            //Send RegisterOrderCommand
            using (var rabbitMqManager = new RabbitMqManager())
            {
                rabbitMqManager.SendRegisterOrderCommand(registerOrderCommand);
            }

            return View("Thanks");
        }
    }
}
