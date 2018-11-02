using System;
using System.Threading.Tasks;
using NServiceBus;

static class Program
{
    static void Main()
    {
        Console.Title = "Samples.PubSub.Subscriber1";

        using (var pub = new Shared.Core.Endpoints.Subscriber<Shared.Core.Messages.Order>())
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}