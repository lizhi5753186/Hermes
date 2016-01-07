using System.Threading;

namespace Hermes.Contracts
{
    public interface IMessageBusEngineContext
    {
        CancellationToken CancellationToken { get; }
    }
}
