using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Web.Model
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
