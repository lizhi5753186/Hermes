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
        private readonly static CancellationTokenSource _engineCancellationTokenSource;

        static MessageBusHost()
        {
            _engineCancellationTokenSource = new CancellationTokenSource();
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }

        /// <summary>
        /// Initializes the Hermes message bus engine.
        /// </summary>
        /// <returns>Initialized Message Bus Engine</returns>
        public static MessageBusEngine GetInitializedMessageBusEngine()
        {
            // Setup internal container. This container will be used to resolve implementations of the IMessageHandler interface...
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

            var context = new MessageBusContext(
                container, 
                _engineCancellationTokenSource.Token
                );

            return new MessageBusEngine(context);
        }

        private static void CurrentDomain_ProcessExit(
            object sender,
            EventArgs e
            )
        {
            // When the application is shutting down, ensure that the engine stop processing and performs a cleanup...
            _engineCancellationTokenSource.Cancel();
        }
    }
}
