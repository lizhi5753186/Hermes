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
                .Hosts[0]
                .Events
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
                .Hosts[0]
                .Events
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
                .Hosts[0]
                .Events
                .Subscribers[0]
                .Type
                .ShouldBe("MyMessageNamespace.SomeOtherMessage, Application.MessagesAssembly");

            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Events
                .Subscribers[1]
                .Type
                .ShouldBe("MyMessageNamespace.SomeOtherMessage1, Application.MessagesAssembly");
        }

        [Test]
        public void ThenSubscriberShouldHaveConcurrency()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Events
                .Subscribers[0]
                .Concurrency
                .Count
                .ShouldBe(10);
        }

        [Test]
        public void ThenSubscriberWithNoConCurrencyShouldHaveDefaultCountOf5()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Events
                .Subscribers[1]
                .Concurrency
                .Count
                .ShouldBe(5);
        }

        [Test]
        public void ThenPublishersShouldHaveTypeNames()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Events
                .Publishers[0]
                .Type
                .ShouldBe("MyMessageNamespace.SomeMessage, Application.MessagesAssembly");

            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Events
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
                .Hosts[0]
                .Events
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
                .Hosts[0]
                .Events
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
                .Hosts[0]
                .Events
                .Subscribers[0]
                .Exchange?
                .ShouldBe("exhangeName");
        }
    }
}
