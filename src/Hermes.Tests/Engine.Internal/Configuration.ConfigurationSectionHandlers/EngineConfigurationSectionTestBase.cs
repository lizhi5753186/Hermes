using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers;

namespace Hermes.Tests.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    public abstract class EngineConfigurationSectionTestBase
    {
        internal EngineConfigurationSection EngineConfigurationSection;

        protected void GivenRabbitMqSectionWasSpecified()
        {
            EngineConfigurationSection = ConfigurationManager.GetSection("hermesConfiguration") as EngineConfigurationSection;
        }
    }
}
