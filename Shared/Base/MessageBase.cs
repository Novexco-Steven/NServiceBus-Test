using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Base
{
    public class MessageBase : Interfaces.IMessageBase
    {
        public Guid Id { get; set; }
        public DateTime DateSent { get; set; }
    }
}
