using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Messaging.Command;

namespace WebStore.RabbitMq.Controllers
{
    public abstract class BaseOrderController<TOrderModel, TOrderCommand> : Controller 
        where TOrderModel : class 
        where TOrderCommand : class, IOrderCommand
    {
        protected readonly MassTransitManager _massTransitManager;
        public BaseOrderController(MassTransitManager massTransitManager)
        {
            _massTransitManager = massTransitManager;
        }

        [HttpPost]
        public virtual async Task<HttpStatusCode> Post([FromBody]TOrderModel model)
        {
            await _massTransitManager.ExecuteCommandOnOrder((TOrderCommand)Activator.CreateInstance(typeof(TOrderCommand), new[] { model }));
            return HttpStatusCode.Accepted;
        }
    }
}
