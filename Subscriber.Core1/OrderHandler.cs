using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Shared.Core.Container;
using Shared.Core.Messages;

namespace Subscriber.Core1
{
    public class OrderHandler : Shared.Core.Handlers.MessageContainerHandler<Shared.Core.Messages.Order>
    {
        public override Task Handle(MessageContainer<Order> message, IMessageHandlerContext context)
        {
            log.Info($"Subscriber has received an Order event with OrderId {message.MessageItem.Id}.");
            return Task.CompletedTask;
        }
    }
}
