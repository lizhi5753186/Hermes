using Hermes.Contracts;

namespace Hermes.Tests.Engine.MessageBusHost
{
    public abstract class MessageBusHostTestBase
    {
        protected IMessageBusEngine MessageBusEngine;

        protected void GivenSuccesfulEngineRetrieval()
        {
            GetMessageBusEngine();
        }

        protected void GivenSuccesfulInitialization()
        {
            GetMessageBusEngine();
        }

        private void GetMessageBusEngine()
        {
            MessageBusEngine = Hermes.Engine
                .MessageBusHost
                .GetEngine();
        }
    }
}
