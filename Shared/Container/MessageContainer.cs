using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Container
{
    public class MessageContainer<T> : IEvent where T : Base.MessageBase
    {
        public MessageContainer()
        {
        }

        public T MessageItem { get; set; }

    }
}
