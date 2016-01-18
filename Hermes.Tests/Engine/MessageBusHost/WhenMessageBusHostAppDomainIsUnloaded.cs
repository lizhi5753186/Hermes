using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.MessageBusHost
{
    [TestFixture]
    [Ignore("Will have to figure out the cross domain eventing")]
    public class WhenMessageBusHostAppDomainIsUnloaded : MessageBusHostTestBase
    {
        [OneTimeSetUp]
        public void Scenario()
        {
            GivenTheMessageBusHostAppDomainIsUnloaded();
        }

        [Test]
        public void ThenMessageBusHostExitCodeShouldExecute()
        {
            IsHostAndEngineShutdown.ShouldBe(true);
        }
    }
}
