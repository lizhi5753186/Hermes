using NUnit.Framework;
using Shouldly;

namespace Hermes.Tests.Engine.MessageBusHost
{
    [TestFixture]
    public class WhenMessageBusHostEngineIsCreated : 
        MessageBusHostTestBase
    {
        [OneTimeSetUp]
        public override void SetupScenario()
        {
            GivenSuccesfulEngineRetrieval();
        }

        [Test]
        public void ThenTheHostShouldPreserveEngineReference()
        {
            object.ReferenceEquals(
                MessageBusEngine,
                Hermes.Engine.MessageBusHost.CurrentEngine
                )
                .ShouldBeTrue();
        }

        [Test]
        public void ThenTheHostShouldShouldPassCancellationTokenToEngine()
        {
            MessageBusEngine.CancellationToken
                .ShouldBe(
                    Hermes.Engine.MessageBusHost.EngineCancellationToken
                    );
        }
    }
}
