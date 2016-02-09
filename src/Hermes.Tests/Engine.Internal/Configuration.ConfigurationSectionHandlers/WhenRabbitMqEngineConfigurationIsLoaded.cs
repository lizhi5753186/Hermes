using System.Linq;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements;
using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    [TestFixture]
    public class WhenRabbitMqEngineConfigurationIsLoaded : 
        EngineConfigurationSectionTestBase
    {
        [OneTimeSetUp]
        public override void SetupScenario()
        {
            GivenRabbitMqSectionWasSpecified();
        }

        [Test]
        public void ThenEngineConfigurationSectionShouldBeLoaded()
        {
            EngineConfigurationSection
                .ShouldNotBeNull();
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
        public void ThenSubscribersShouldBeLoaded()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Subscribers
                .Count
                .ShouldNotBe(0);
        }

        [Test]
        public void ThenSubscribersShouldHaveTypeNames()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Subscribers[0]
                .Type
                .ShouldBe("MyMessageNamespace.SomeOtherMessage, Application.MessagesAssembly");

            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Subscribers[1]
                .Type
                .ShouldBe("MyMessageNamespace.SomeOtherMessage1, Application.MessagesAssembly");
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

        [Test]
        public void ThenPublisherWithExchangeShouldContainExchangeName()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Publishers[0]
                .Exchange?
                .ShouldBe("exhangeName");
        }

        [Test]
        public void ThenSubscriberWithExchangeShouldContainExchangeName()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Subscribers[0]
                .Exchange?
                .ShouldBe("exhangeName");
        }

        [Test]
        public void ThenHostShouldBeInHostList()
        {
            var hosts =
                EngineConfigurationSection
                    .Transport
                    .RabbitMq
                    .Hosts
                    .Cast<HostConfigurationElement>()
                    .Select(x => x.Name)
                    .ToArray();

            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Publishers[0]
                .Host.ShouldBeOneOf(hosts);

            //    .ShouldBe("exhangeName");
        }
    }
}
