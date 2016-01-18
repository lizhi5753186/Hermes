using System;
using System.Threading;
using Hermes.Contracts;
using Hermes.Engine;

namespace Hermes.UnitTest.Helpers
{
    /// <summary>
    /// This class is for usage during Unit Tests. Since it is difficult to test static types, this wrapper will allow us
    /// to run the Host in a controlled (dynamically created Application Domain) which could be tracked to monitor object lifetimes
    /// and destruction logic.
    /// </summary>
    public class MessageBusHostProxy : 
        MarshalByRefObject
    {
        public CancellationToken EngineCancellationToken
            => MessageBusHost.EngineCancellationToken;

        public IMessageBusEngine CurrentEngine
            => MessageBusHost.CurrentEngine;

        public event EventHandler<IMessageBusEngine> ShuttingDown
        {
            add { MessageBusHost.ShuttingDown += value; }
            remove { MessageBusHost.ShuttingDown -= value; }
        }

        public event EventHandler<IMessageBusEngine> ShutdownCompleted
        {
            add { MessageBusHost.ShutdownCompleted += value; }
            remove { MessageBusHost.ShutdownCompleted -= value; }
        }

        public IMessageBusEngine GetEngine()
        {
            return MessageBusHost.GetEngine();
        }
    }
}
