using Hermes.Contracts;
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
        private static readonly CancellationTokenSource EngineCancellationTokenSource;

        /// <summary>
        /// Invoked before any finalization code is executed.
        /// </summary>
        public static event EventHandler<IMessageBusEngine> ShuttingDown;

        /// <summary>
        /// Executed after the host has completed the engine shutdown logic.
        /// </summary>
        public static event EventHandler<IMessageBusEngine> ShutdownCompleted;

        /// <summary>
        /// The current cancellation token for the Engine.
        /// </summary>
        public static CancellationToken EngineCancellationToken 
            => EngineCancellationTokenSource.Token;

        /// <summary>
        /// This is to keep a reference to the engine and in doing so keeping it from being garbage collected until an explicit shutdown. The alternative
        /// is to run the engine on a seperate thread. This should be investigated...
        /// </summary>
        public static IMessageBusEngine CurrentEngine { get; private set; }

        static MessageBusHost()
        {
            CurrentEngine = null;
            EngineCancellationTokenSource = new CancellationTokenSource();
            AppDomain.CurrentDomain.ProcessExit += ShutdownHost;

            // This event is a convenience hook into the DomainUnload. This will only fire when this class is hosted in an AppDomain created during runtime.
            // In order to enable lifetime tracking during unit testing, this event will allow us monitor the class' lifetime.
            AppDomain.CurrentDomain.DomainUnload += ShutdownHost;
        }

        /// <summary>
        /// Initializes the Hermes message bus engine. This returns an Engine Singleton.
        /// </summary>
        /// <returns>Initialized Message Bus Engine</returns>
        public static IMessageBusEngine GetEngine()
        {
            if (CurrentEngine != null)
            {
                return CurrentEngine;
            }

            CurrentEngine = new MessageBusEngine(
                new MessageBusEngineContext(
                    EngineCancellationTokenSource.Token
                    )
                );

            return CurrentEngine;
        }

        /// <summary>
        /// This will shutdown the Engine in the event the application stops running (Application Domain shuts down). At the moment this is 
        /// the only shutdown mechanism.
        /// </summary>
        /// <param name="sender">Invoker of the Event</param>
        /// <param name="e">Event Arguments</param>
        private static void ShutdownHost(
            object sender, 
            EventArgs e
            )
        {
            InvokeShuttingDownEvent();

            EngineCancellationTokenSource.Cancel();

            InvokeShutdownCompletedEvent();
        }

        private static void InvokeShutdownCompletedEvent()
        {
            var afterEvent = ShutdownCompleted;
            InvokeEvent(afterEvent);
        }

        private static void InvokeShuttingDownEvent()
        {
            var beforeEvent = ShuttingDown;
            InvokeEvent(beforeEvent);
        }

        private static void InvokeEvent(
            EventHandler<IMessageBusEngine> evt
            )
        {
            evt?.Invoke(
                null,
                CurrentEngine
                );
        }
    }
}
