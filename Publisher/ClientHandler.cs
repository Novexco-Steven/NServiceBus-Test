using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Shared.Core.Container;
using Shared.Core.Messages;

namespace Publisher.Core
{
    public class ClientHandler : Shared.Core.Handlers.MessageContainerHandler<Shared.Core.Messages.Client>
    {
        public override Task Handle(MessageContainer<Client> message, IMessageHandlerContext context)
        {
            log.Info($"Publisher has sent a Client event with Id {message.MessageItem.Id}.");
            return Task.CompletedTask;
        }
    }
}
