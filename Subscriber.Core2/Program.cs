using System;
using System.Threading.Tasks;
using NServiceBus;

static class Program
{
    static void Main()
    {
        Console.Title = "Samples.PubSub.Subscriber2";

        using (var pub = new Shared.Core.Endpoints.Subscriber<Shared.Core.Messages.Client>())
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}