using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    [TestFixture]
    public class WhenRabbitMqEngineConfigurationIsLoadedWithHosts : 
        EngineConfigurationSectionTestBase
    {
        [OneTimeSetUp]
        public override void SetupScenario()
        {
            GivenRabbitMqSectionWasSpecified();
        }

        [Test]
        public void ThenHostsShouldBeLoaded()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts
                .ShouldNotBeNull();
        }
    }
}
