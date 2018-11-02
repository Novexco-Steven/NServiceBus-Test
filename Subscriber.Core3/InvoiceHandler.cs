﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Shared.Core.Container;
using Shared.Core.Messages;

namespace Subscriber.Core3
{
    public class InvoiceHandler : Shared.Core.Handlers.MessageContainerHandler<Shared.Core.Messages.Invoice>
    {
        public override Task Handle(MessageContainer<Invoice> message, IMessageHandlerContext context)
        {
            log.Info($"Subscriber has received an Invoice event with Id {message.MessageItem.Id}.");
            return Task.CompletedTask;
        }
    }
}
