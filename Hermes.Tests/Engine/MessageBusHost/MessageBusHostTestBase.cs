using System;
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
        protected bool IsHostAndEngineShutdown = false;

        protected void GivenSuccesfulEngineRetrieval()
        {
            GetMessageBusEngine();
        }

        protected void GivenAnEngineWasPreviouslyRetrieved()
        {
            GetMessageBusEngine();
            GetSecondMessageBusEngine();
        }

        protected void GivenTheMessageBusHostIsShutdown()
        {
            Hermes.Engine
                .MessageBusHost
                .ShutdownCompleted += MessageBusHost_ShutdownCompleted;

            Hermes.Engine
                .MessageBusHost
                .Shutdown();
        }

        private void MessageBusHost_ShutdownCompleted(object sender, IMessageBusEngine e)
        {
            // TODO: Check if engine was diposed...
            IsHostAndEngineShutdown = true;
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
