using Microsoft.AspNetCore.Mvc;
using WebStore.Web.Model;
using WebStore.Web.Messages;

namespace WebStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class CompleteOrderController : BaseOrderController<CompleteOrderViewModel, CompleteOrderCommand>
    {
        public CompleteOrderController(MassTransitManager massTransitManager) : base(massTransitManager)
        { }
    }
}
