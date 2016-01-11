using System.Collections.Generic;

namespace Hermes.Contracts.Internal
{
    internal interface IMessageBusMessage
    {
        IReadOnlyDictionary<string, object> Headers { get; set; }
        IMessage Message { get; set; }
    }
}
