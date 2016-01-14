using Shouldly;
using NUnit.Framework;

namespace Hermes.Tests.Engine.MessageBusHost
{
    [TestFixture]
    public class WhenMessageBusHostEngineWasPreviouslyCreated : MessageBusHostTestBase
    {
        [OneTimeSetUp]
        public void Scenario()
        {
            GivenAnEngineWasPreviouslyRetrieved();
        }

        [Test]
        public void ThenTheSameEngineReferenceShouldBeReturned()
        {
            object.ReferenceEquals(
                MessageBusEngine,
                Hermes.Engine.MessageBusHost.CurrentEngine
                )
                .ShouldBeTrue();
        }

        [Test]
        public void ThenTheHostShouldShouldPassTheOriginalCancellationTokenToEngine()
        {
            CreatedCancellationToken.ShouldSatisfyAllConditions(
                () => CreatedCancellationToken.ShouldBe(Hermes.Engine.MessageBusHost.EngineCancellationToken),
                () => CreatedCancellationToken.ShouldBe(SecondCreatedCancellationToken)
                );
        }
    }
}
