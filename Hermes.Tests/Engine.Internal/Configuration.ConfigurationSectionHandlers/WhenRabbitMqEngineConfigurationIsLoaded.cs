using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    [TestFixture]
    public class WhenRabbitMqEngineConfigurationIsLoaded : 
        EngineConfigurationSectionTestBase
    {
        [OneTimeSetUp]
        public void Scenario()
        {
            GivenRabbitMqSectionWasSpecified();
        }

        [Test]
        public void ThenEngineConfigurationSectionMustBeLoaded()
        {
            EngineConfigurationSection.ShouldNotBeNull();
        }
    }
}
