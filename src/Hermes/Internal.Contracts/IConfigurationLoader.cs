using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers;

namespace Hermes.Internal.Contracts
{
    internal interface IConfigurationLoader
    {
        EngineConfiguration Load();
    }
}
