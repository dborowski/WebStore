using System;

namespace WebStore.RabbitMq.Model
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
