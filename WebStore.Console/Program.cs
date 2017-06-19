using WebStore.Messaging.RabbitMq;

namespace WebStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var registerOrderCommand = new RegisterOrderCommand(
                new OrderViewModel
                {
                    DeliverAddress = "SomeAddr",
                    DeliverCity = "SomeCity",
                    
                });
            using (var rabbitMqManager = new RabbitMqManager())
            {
                //rabbitMqManager.SendRegisterOrderCommand(registerOrderCommand);
            }
            System.Console.ReadLine();
        }
    }
}
