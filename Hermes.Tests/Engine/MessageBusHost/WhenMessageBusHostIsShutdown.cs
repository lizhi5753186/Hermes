using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.MessageBusHost
{
    [TestFixture]
    public class WhenMessageBusHostIsShutdown : 
        MessageBusHostTestBase
    {
        [OneTimeSetUp]
        public void Scenario()
        {
            GivenTheMessageBusHostIsShutdown();
        }

        [Test]
        public void ThenMessageBusHostExitCodeShouldExecute()
        {
            IsHostAndEngineShutdown.ShouldBe(true);
        }
    }
}
