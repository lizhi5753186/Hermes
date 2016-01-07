using Hermes.Internals;
using System;
using System.Threading;

namespace Hermes.Engine
{
    /// <summary>
    /// Hermes Message Bus Host. The Host controls the lifetime of the Message Bus Engine.
    /// </summary>
    public static class MessageBusHost
    {
        // TODO : Need to implement duplex communication between Host and Engine to coordinate shutdown...
        // This is to keep a reference to the engine and in doing so keeping it from being garbage collected until explcit shutdown... 
        private static MessageBusEngine _messageBusEngine;
        private static readonly CancellationTokenSource EngineCancellationTokenSource;

        static MessageBusHost()
        {
            _messageBusEngine = null;
            EngineCancellationTokenSource = new CancellationTokenSource();
            AppDomain.CurrentDomain.ProcessExit += ApplicationDomainShutdown;
        }

        /// <summary>
        /// Initializes the Hermes message bus engine.
        /// </summary>
        /// <returns>Initialized Message Bus Engine</returns>
        public static MessageBusEngine GetEngine()
        {
            if (_messageBusEngine != null)
            {
                return _messageBusEngine;
            }

            _messageBusEngine = new MessageBusEngine(
                new MessageBusEngineContext(
                    EngineCancellationTokenSource.Token
                    )
                );

            return _messageBusEngine;
        }

        private static void ApplicationDomainShutdown(
            object sender,
            EventArgs e
            )
        {
            // When the application is shutting down, ensure that the engine stop processing and performs a cleanup...
            EngineCancellationTokenSource.Cancel();
        }
    }
}
