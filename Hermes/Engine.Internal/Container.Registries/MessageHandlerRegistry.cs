using Hermes.Contracts;
using StructureMap;
using StructureMap.Graph;

namespace Hermes.Engine.Internal.Container.Registries
{
    public class MessageHandlerRegistry : Registry
    {
        public MessageHandlerRegistry()
        {
            Scan(scanner =>
            {
                // Container Usage Guidelines: https://lostechies.com/jimmybogard/2014/09/17/container-usage-guidelines/

                // TODO : Might want to restrict the types being loaded into this container... Stream line type registration... Create
                // custom attribute of types of interest to the engine...
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.ConnectImplementationsToTypesClosing(typeof(IMessageHandler<>));
                scanner.LookForRegistries();
            });
        }
    }
}
