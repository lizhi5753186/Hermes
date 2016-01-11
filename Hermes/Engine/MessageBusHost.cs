using Hermes.Engine.Internal;
using System;
using System.Threading;

namespace Hermes.Engine
{
    /// <summary>
    /// Hermes Message Bus Host. The Host controls the lifetime of the Message Bus Engine.
    /// </summary>
    public static class MessageBusHost
    {
        // This is to keep a reference to the engine and in doing so keeping it from being garbage collected until an explicit shutdown... The alternative
        // is to run the engine on a seperate thread. This should be investigated...
        private static MessageBusEngine _messageBusEngine;
        private static readonly CancellationTokenSource EngineCancellationTokenSource;

        static MessageBusHost()
        {
            _messageBusEngine = null;
            EngineCancellationTokenSource = new CancellationTokenSource();
            AppDomain.CurrentDomain.ProcessExit += ApplicationDomainShutdown;
        }

        /// <summary>
        /// Initializes the Hermes message bus engine. This returns an Engine Singleton.
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

        /// <summary>
        /// This will shutdown the Engine in the event the application stops running (Application Domain shuts down). At the moment this is 
        /// the only shutdown mechanism.
        /// </summary>
        /// <param name="sender">Invoker of the Event</param>
        /// <param name="e">Event Arguments</param>
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
