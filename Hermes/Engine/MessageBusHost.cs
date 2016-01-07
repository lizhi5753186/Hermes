using Hermes.Contracts;
using Hermes.Internals;
using StructureMap;
using StructureMap.Graph;
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
        private readonly static CancellationTokenSource _engineCancellationTokenSource;

        static MessageBusHost()
        {
            _messageBusEngine = null;
            _engineCancellationTokenSource = new CancellationTokenSource();
            AppDomain.CurrentDomain.ProcessExit += ApplicationDomainShutdown;
        }

        /// <summary>
        /// Initializes the Hermes message bus engine.
        /// </summary>
        /// <returns>Initialized Message Bus Engine</returns>
        public static MessageBusEngine GetInitializedMessageBusEngine()
        {
            if (_messageBusEngine != null)
            {
                return _messageBusEngine;
            }

            // Setup internal DI container. This container will be used to resolve implementations of the IMessageHandler interface...
            var container = new Container(c =>
            {
                c.Scan(scanner =>
                {
                    // TODO : Might want to restrict the types being loaded into this container...
                    scanner.AssembliesFromApplicationBaseDirectory();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IMessageHandler<>));
                    scanner.LookForRegistries();
                });
            });

            // TODO : Read and parse custom config sections in config files...
            // TODO : Bootstrap RabbitMQ Client...

            _messageBusEngine = new MessageBusEngine(
                new MessageBusContext(
                    container,
                    _engineCancellationTokenSource.Token
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
            _engineCancellationTokenSource.Cancel();
        }
    }
}
