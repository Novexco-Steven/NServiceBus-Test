using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Interfaces
{
    public interface IMessageBase
    {
        Guid Id { get; set; }
        DateTime DateSent { get; set; }

    }
}
