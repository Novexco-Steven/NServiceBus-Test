using System;
using System.Threading.Tasks;
using NServiceBus;
using Shared.Core;

static class Program
{
    static void Main()
    {
        Console.Title = "Samples.PubSub.Publisher";

        Start();
    }

    static void Start()
    {
        Console.WriteLine("Press '1' to publish the Order event");
        Console.WriteLine("Press '2' to publish the Client event");
        Console.WriteLine("Press '3' to publish the Invoice event");
        Console.WriteLine("Press any other key to exit");

        #region PublishLoop

        while (true)
        {
            var key = Console.ReadKey();
            Console.WriteLine();

            var orderReceivedId = Guid.NewGuid();

            if (key.Key == ConsoleKey.D1)
            {
                var mc = new Shared.Core.Container.MessageContainer<Shared.Core.Messages.Order>()
                {
                    MessageItem = new Shared.Core.Messages.Order
                    {
                        Id = orderReceivedId
                    }
                };

                using (var pub = new Shared.Core.Endpoints.Publisher<Shared.Core.Messages.Order>())
                {
                    pub.Publish(mc);
                }

                Console.WriteLine($"Publising Order Event.");
            }
            else if(key.Key == ConsoleKey.D2)
            {
                var mc = new Shared.Core.Container.MessageContainer<Shared.Core.Messages.Client>()
                {
                    MessageItem = new Shared.Core.Messages.Client
                    {
                        Id = orderReceivedId
                    }
                };

                using (var pub = new Shared.Core.Endpoints.Publisher<Shared.Core.Messages.Client>())
                {
                    pub.Publish(mc);
                }

                Console.WriteLine($"Publising Client Event.");
            }
            else if (key.Key == ConsoleKey.D3)
            {
                var mc = new Shared.Core.Container.MessageContainer<Shared.Core.Messages.Invoice>()
                {
                    MessageItem = new Shared.Core.Messages.Invoice
                    {
                        Id = orderReceivedId
                    }
                };

                using (var pub = new Shared.Core.Endpoints.Publisher<Shared.Core.Messages.Invoice>())
                {
                    pub.Publish(mc);
                }

                Console.WriteLine($"Publising Invoice Event.");
            }
            else
            {
                return;
            }
        }

        #endregion
    }
}