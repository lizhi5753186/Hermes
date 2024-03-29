﻿using Hermes.Contracts;
using System;
using System.Threading;
using Hermes.Internal.Contracts;
using StructureMap;
using StructureMap.Graph;

namespace Hermes.Engine
{
    /// <summary>
    /// A class representing a Hermes message bus engine.
    /// </summary>
    public class MessageBusEngine : 
        IMessageBusEngine
    {
        private bool _disposed = false;
        private Container _container = null;
        private readonly IMessageBusEngineContext _messageBusEngineContext;
        private readonly IEngineExecutionContext _executionContext;

        public CancellationToken CancellationToken
            => _messageBusEngineContext.CancellationToken;

        /// <summary>
        /// This class can only be instantiated by types internal to this assembly.
        /// </summary>
        /// <param name="engineContext"></param>
        /// <param name="engineExecutionContext"></param>
        internal MessageBusEngine(
            IMessageBusEngineContext engineContext, 
            IEngineExecutionContext engineExecutionContext
            )
        {
            _messageBusEngineContext = engineContext;
            _executionContext = engineExecutionContext;
        }

        /// <summary>
        /// Start the Message Bus Engine. This will start dispatching and consuming messages.
        /// </summary>
        public void Start()
        {
            _executionContext.Initialize(() =>
            {
                Initialize();

                // TODO : Thread throttling to help with debugging... Config setting perhaps?
                // Concurrency Control: https://msdn.microsoft.com/en-us/library/ee789351%28v=vs.110%29.aspx
                //                      https://msdn.microsoft.com/en-us/library/dd997402(v=vs.110).aspx
                // RabbitMQ message consumption: https://www.rabbitmq.com/dotnet-api-guide.html
            });
        }

        /// <summary>
        /// Publish a message onto the Message Bus.
        /// </summary>
        /// <typeparam name="T">Message of Type T</typeparam>
        /// <param name="message">Concrete Message</param>
        public void Publish<T>(
            T message
            )
            where T : class, IMessage
        {
            _executionContext.Execute(() =>
            {
                // Lookup message type and load config...
                // Send message...
            });
        }

        /// <summary>
        /// Initializes the Message Bus Engine.
        /// </summary>
        /// <returns>An initialized Message Bus Engine</returns>
        private void Initialize()
        {
            // Setup internal DI container. This container will be used to resolve implementations of the IMessageHandler interface...
            _container = new Container(c =>
            {
                c.Scan(scanner =>
                {
                    // TODO : Might want to restrict the types being loaded into this container... Stream line type registration... Create
                    // custom attribute of types of interest to the engine...
                    scanner.TheCallingAssembly();
                    scanner.LookForRegistries();
                });
            });

            // Get the configuration setup for the Engine...
            var configLoader = _container.GetInstance<IConfigurationLoader>();
            var config = configLoader.Load();

            // TODO : Bootstrap the Transport mapping... each transport should be implement with a common interface with the details abstracted away. Both publish and subscribe.

            // TODO : Bootstrap Transport Clients... put in own Strategy (this will allow to add MSMQ 'plugin')
            // return a MessageTransportManager (Mediator pattern?)
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(
            bool disposing
            )
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO : Dispose managed resources...
            }

            _disposed = true;
        }

        ~MessageBusEngine()
        {
            Dispose(false);
        }
    }
}
