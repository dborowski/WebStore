using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using WebStore.Web.Model;
using WebStore.Web.Messages;

namespace WebStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class RegisterOrderController : BaseOrderController<OrderViewModel, RegisterOrderCommand>
    {
        public RegisterOrderController(MassTransitManager massTransitManager) : base(massTransitManager)
        {
        }
    }
}
