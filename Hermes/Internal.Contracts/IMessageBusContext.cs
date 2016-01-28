using System.Threading;

namespace Hermes.Internal.Contracts
{
    internal interface IMessageBusEngineContext
    {
        CancellationToken CancellationToken { get; }
    }
}
