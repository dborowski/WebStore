using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.RabbitMq.Hub
{
    public class SignalHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public void RegisterOrder(string order)
        {
            Debug.WriteLine(Context.ConnectionId);
            // Call the broadcastMessage method to update clients.
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }


        public override Task OnConnected()
        {
            Clients.Caller.myId(Context.ConnectionId);
            return base.OnConnected();
        }
    }
}
