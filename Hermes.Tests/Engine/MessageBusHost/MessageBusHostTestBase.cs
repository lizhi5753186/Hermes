using System.Threading;
using Hermes.Contracts;

namespace Hermes.Tests.Engine.MessageBusHost
{
    public abstract class MessageBusHostTestBase
    {
        protected IMessageBusEngine MessageBusEngine;
        protected IMessageBusEngine SecondMessageBusEngine;
        protected CancellationToken CreatedCancellationToken;
        protected CancellationToken SecondCreatedCancellationToken;

        protected void GivenSuccesfulEngineRetrieval()
        {
            GetMessageBusEngine();
        }

        protected void GivenAnEngineWasPreviouslyRetrieved()
        {
            GetMessageBusEngine();
            GetSecondMessageBusEngine();
        }

        protected void GivenSuccesfulInitialization()
        {

        }

        private void GetMessageBusEngine()
        {
            MessageBusEngine = Hermes.Engine
                .MessageBusHost
                .GetEngine();

            CreatedCancellationToken = MessageBusEngine.CancellationToken;
        }

        private void GetSecondMessageBusEngine()
        {
            SecondMessageBusEngine = Hermes.Engine
                .MessageBusHost
                .GetEngine();

            SecondCreatedCancellationToken = MessageBusEngine.CancellationToken;
        }

    }
}
