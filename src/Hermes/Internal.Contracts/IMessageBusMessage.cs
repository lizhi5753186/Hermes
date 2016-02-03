using System.Collections.Generic;
using Hermes.Contracts;

namespace Hermes.Internal.Contracts
{
    internal interface IMessageBusMessage
    {
        IReadOnlyDictionary<string, object> Headers { get; set; }
        IMessage Message { get; set; }
    }
}
