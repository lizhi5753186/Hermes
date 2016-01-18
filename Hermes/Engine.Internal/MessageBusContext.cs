using System;
using Hermes.Contracts.Internal;
using System.Threading;

namespace Hermes.Engine.Internal
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
