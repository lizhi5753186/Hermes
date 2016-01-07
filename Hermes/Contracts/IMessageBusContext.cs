using StructureMap;
using System.Threading;

namespace Hermes.Contracts
{
    public interface IMessageBusContext
    {
        Container Container { get; }
        CancellationToken CancellationToken { get; }
    }
}
