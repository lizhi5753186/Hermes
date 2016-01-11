using System.Threading;

namespace Hermes.Contracts.Internal
{
    internal interface IMessageBusEngineContext
    {
        CancellationToken CancellationToken { get; }
    }
}
