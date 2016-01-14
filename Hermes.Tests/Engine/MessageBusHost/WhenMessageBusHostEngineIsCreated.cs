using NUnit.Framework;

namespace Hermes.Tests.Engine.MessageBusHost
{
    [TestFixture]
    public class WhenMessageBusHostEngineIsCreated : MessageBusHostTestBase
    {
        [OneTimeSetUp]
        public void Scenario()
        {
            GivenSuccesfulEngineRetrieval();
        }

        [Test]
        public void ThenTheHostShouldPreserveEngineReference()
        {
            Assert.IsTrue(
                object.ReferenceEquals(
                    MessageBusEngine, 
                    Hermes.Engine.MessageBusHost.CurrentEngine
                    )
                );
        }

        [Test]
        public void ThenTheHostShouldShouldPassCancellationTokenToEngine()
        {
            Assert.AreEqual(
                MessageBusEngine.CancellationToken,
                Hermes.Engine.MessageBusHost.EngineCancellationToken
                );
        }
    }
}
