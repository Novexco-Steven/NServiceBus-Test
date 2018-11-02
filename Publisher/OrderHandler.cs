using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Shared.Core.Container;
using Shared.Core.Messages;

namespace Publisher.Core
{
    public class OrderHandler : Shared.Core.Handlers.MessageContainerHandler<Shared.Core.Messages.Order>
    {
        public override Task Handle(MessageContainer<Order> message, IMessageHandlerContext context)
        {
            log.Info($"Publisher has sent an Order event with Id {message.MessageItem.Id}.");
            return Task.CompletedTask;
        }
    }
}
