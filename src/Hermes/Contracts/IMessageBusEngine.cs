using System;
using System.Threading;

namespace Hermes.Contracts
{
    /// <summary>
    /// The contract describing the MessageBusEngine.
    /// </summary>    
    public interface IMessageBusEngine : 
        IDisposable
    {
        /// <summary>
        /// Get the CancellationToken for this Engine.
        /// </summary>
        CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initializes the Hermes message bus engine.
        /// </summary>
        /// <returns>Initialized Message Bus Engine</returns>
        IMessageBusEngine Initialize();

        /// <summary>
        /// Starts the Hermes message bus engine.
        /// </summary>
        void Start();

        /// <summary>
        /// Publishes and Event to the queue.
        /// </summary>
        /// <typeparam name="T">Message Type</typeparam>
        /// <param name="message">Message to publish</param>
        void Publish<T>(T message)
            where T : class, IMessage;
    }
}
