using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Handlers
{
    public abstract class MessageContainerHandler<T> : IHandleMessages<Container.MessageContainer<T>> where T : Base.MessageBase
    {
        public static readonly ILog log = LogManager.GetLogger<Container.MessageContainer<T>>();

        public abstract Task Handle(Container.MessageContainer<T> message, IMessageHandlerContext context);
    }
}
