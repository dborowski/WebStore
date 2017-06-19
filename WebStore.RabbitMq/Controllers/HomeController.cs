using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Console;
using WebStore.Messaging.RabbitMq;

namespace WebStore.RabbitMq.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult RegisterOrder()
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
