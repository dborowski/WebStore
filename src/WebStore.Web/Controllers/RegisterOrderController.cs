using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Web.Model;
using System.Net;

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
        public async Task<HttpStatusCode> Post([FromBody]OrderViewModel model)
        {
            await _massTransitManager.RegisterOrder(new Messages.RegisterOrderCommand(model));
            return HttpStatusCode.Accepted;
        }
    }
}
