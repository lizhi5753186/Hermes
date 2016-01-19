using Hermes.Contracts;
using Hermes.Engine.Internal;
using System;
using System.Linq;
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
            AppDomain.CurrentDomain.ProcessExit += Shutdown;
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
        /// This will perform the sequenced shutdown of the Engine when the engine is manually shutdown. 
        /// </summary>
        public static void Shutdown()
        {
            Shutdown(
                null,
                new EventArgs()
                );
        }

        /// <summary>
        /// This will perform the sequenced shutdown of the Engine when application stops running. This is the handler for the AppDomain
        /// Processexit event.
        /// </summary>
        /// <param name="sender">Invoker of the Event</param>
        /// <param name="e">Event Arguments</param>
        private static void Shutdown(
            object sender,
            EventArgs e
            )
        {
            RaiseShuttingDownEvent();
            EngineCancellationTokenSource.Cancel();
            RaiseShutdownCompletedEvent();

            Cleanup();
        }

        private static void RaiseShutdownCompletedEvent()
        {
            var afterEvent = ShutdownCompleted;
            RaiseEvent(afterEvent);
        }

        private static void RaiseShuttingDownEvent()
        {
            var beforeEvent = ShuttingDown;
            RaiseEvent(beforeEvent);
        }

        /// <summary>
        /// Generic event invoker.
        /// </summary>
        /// <param name="evt">Event to raise</param>
        private static void RaiseEvent(
            EventHandler<IMessageBusEngine> evt
            )
        {
            evt?.Invoke(
                null,
                CurrentEngine
                );
        }

        /// <summary>
        /// This method performs all kinds of resource cleanup.
        /// </summary>
        private static void Cleanup()
        {
            UnsubscribeShutDownCompletedSubscribers();
            UnsubscribeShuttingDownSubscribers();

            AppDomain.CurrentDomain.ProcessExit -= Shutdown;
        }

        private static void UnsubscribeShuttingDownSubscribers()
        {
            ShuttingDown = null;
        }

        private static void UnsubscribeShutDownCompletedSubscribers()
        {
            ShutdownCompleted = null;
        }
    }
}
