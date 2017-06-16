using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Web.Model;

namespace WebStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class RegisterOrderController : Controller
    {
        private readonly MassTransitManager _massTransitManager;
        public RegisterOrderController(MassTransitManager massTransitManager)
        {
            _massTransitManager = massTransitManager;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]OrderViewModel model)
        {
            _massTransitManager.RegisterOrder(new Messages.RegisterOrderCommand(model));
        }
    }
}
