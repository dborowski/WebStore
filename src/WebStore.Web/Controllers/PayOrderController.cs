using Microsoft.AspNetCore.Mvc;
using WebStore.Web.Model;
using WebStore.Web.Messages;

namespace WebStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class PayOrderController : BaseOrderController<PayOrderViewModel, PayOrderCommand>
    {
        public PayOrderController(MassTransitManager massTransitManager) : base(massTransitManager)
        { }
    }
}
