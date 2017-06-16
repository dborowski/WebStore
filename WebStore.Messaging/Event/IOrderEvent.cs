using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Messaging.Event
{
    public interface IOrderEvent
    {
        Guid Id { get; set; }
    }
}
