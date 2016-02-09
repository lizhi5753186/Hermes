using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Enums;
using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    [TestFixture]
    public class WhenRabbitMqEngineConfigurationIsLoadedWithHostAndExchanges : 
        EngineConfigurationSectionTestBase
    {
        [OneTimeSetUp]
        public override void SetupScenario()
        {
            GivenRabbitMqSectionWasSpecified();
        }

        [Test]
        public void ThenExchangesShouldBeLoaded()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Exchanges
                .ShouldNotBeNull();
        }

        [Test]
        public void ThenExchangeTypeShouldBeFanoutIfSetAsFanout()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Exchanges[0]
                .Type
                .ShouldBe(RabbitMqExchangeType.Fanout);
        }

        [Test]
        public void ThenExchangeTypeShouldBeFanoutIfNotSpecified()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Exchanges[1]
                .Type
                .ShouldBe(RabbitMqExchangeType.Fanout);
        }

        [Test]
        public void ThenExchangeTypeShouldBeDirectIfSetAsDirect()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Exchanges[2]
                .Type
                .ShouldBe(RabbitMqExchangeType.Direct);
        }

        [Test]
        public void ThenExchangeTypeShouldBeTopicIfSetAsTopic()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Exchanges[3]
                .Type
                .ShouldBe(RabbitMqExchangeType.Topic);
        }

        [Test]
        public void ThenExchangeTypeShouldBeHeadersIfSetAsHeaders()
        {
            EngineConfigurationSection
                .Transport
                .RabbitMq
                .Hosts[0]
                .Exchanges[4]
                .Type
                .ShouldBe(RabbitMqExchangeType.Headers);
        }
    }
}
