using System.Threading;
using Hermes.Internal.Contracts;

namespace Hermes.Internal.Engine
{
    /// <summary>
    /// Context needed by the Message Bus Engine.
    /// </summary>
    internal class MessageBusEngineContext : 
        IMessageBusEngineContext
    {
        public CancellationToken CancellationToken { get; private set; }

        public MessageBusEngineContext(
            CancellationToken cancellationToken
            )
        {
            CancellationToken = cancellationToken;
        }
    }
}
