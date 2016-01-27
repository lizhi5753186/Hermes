using System.Linq;
using Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements;
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
        public void ThenEngineConfigurationSectionShouldBeLoaded()
        {
            EngineConfigurationSection.ShouldNotBeNull();
        }

        [Test]
        public void ThenExchangesShouldBeLoaded()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Exchanges
                .Count
                .ShouldNotBe(0);
        }

        [Test]
        public void ThenPublishersShouldBeLoaded()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Publishers
                .Count
                .ShouldNotBe(0);
        }

        [Test]
        public void ThenPublishersShouldHaveTypeNames()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Publishers[0]
                .Type
                .ShouldBe("MyMessageNamespace.SomeMessage, Application.MessagesAssembly");

            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Publishers[1]
                .Type
                .ShouldBe("MyMessageNamespace.SomeMessage1, Application.MessagesAssembly");
        }

        [Test]
        public void ThenShouldNotContainDuplicatePublishers()
        {
            var publishers = EngineConfigurationSection
                .Transport
                .RabbitMq
                .Publishers
                .Cast<MessageConfigurationElement>();

            publishers
                .Count(x => x.Type == "MyMessageNamespace.SomeMessage1, Application.MessagesAssembly")
                .ShouldBe(1);
        }
    }
}
