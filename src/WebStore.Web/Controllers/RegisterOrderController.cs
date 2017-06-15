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
        // GET api/values
        [HttpGet]
        public IEnumerable<OrderViewModel> Get()
        {
            return new OrderViewModel[] { };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public OrderViewModel Get(Guid id)
        {
            return new OrderViewModel();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]OrderViewModel value)
        {
        }
    }
}
