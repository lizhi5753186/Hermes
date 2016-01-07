using Hermes.Contracts;
using StructureMap;
using System.Threading;

namespace Hermes.Internals
{
    /// <summary>
    /// Context needed by the Message Bus Engine.
    /// </summary>
    internal class MessageBusContext : IMessageBusContext
    {
        public Container Container { get; private set; }
        public CancellationToken CancellationToken { get; private set; }

        public MessageBusContext(
            Container container, 
            CancellationToken cancellationToken
            )
        {
            Container = container;
            CancellationToken = cancellationToken;
        }
    }
}
