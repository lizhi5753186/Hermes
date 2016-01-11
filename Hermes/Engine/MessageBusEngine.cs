using Hermes.Contracts;
using Hermes.Contracts.Internal;
using System;
using StructureMap;
using StructureMap.Graph;
using Hermes.Engine.Internal;

namespace Hermes.Engine
{
    /// <summary>
    /// A class representing a Hermes message bus engine.
    /// </summary>
    public class MessageBusEngine : IDisposable
    {
        private Container _container;
        private IMessageSenderFactory _messageSenderFactory;
        private readonly IMessageBusEngineContext _messageBusEngineContext;
        

        internal MessageBusEngine(
            IMessageBusEngineContext engineContext
            )
        {
            _messageBusEngineContext = engineContext;
        }

        /// <summary>
        /// Initializes the Hermes message bus engine.
        /// </summary>
        /// <returns>Initialized Message Bus Engine</returns>
        public MessageBusEngine Initialize()
        {
            // Setup internal DI container. This container will be used to resolve implementations of the IMessageHandler interface...
            _container = new Container(c =>
            {
                c.Scan(scanner =>
                {
                    // TODO : Might want to restrict the types being loaded into this container...
                    scanner.AssembliesFromApplicationBaseDirectory();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IMessageHandler<>));
                    scanner.LookForRegistries();
                });
            });

            // Setup the MessageSenderFactory...
            _messageSenderFactory = new MessageSenderFactory(_container);


            // TODO : Read and parse custom config sections in config files...
            // TODO : Bootstrap RabbitMQ Client...

            return this;
        }

        /// <summary>
        /// Starts the Hermes message bus engine.
        /// </summary>
        public void Start()
        {
            // TODO : Thread throttling to help with debugging... Config setting perhaps?
            // TODO : Start a Task to perform work with cancellation token which will be set in the Dispose method...
            // Concurrency Control: https://msdn.microsoft.com/en-us/library/ee789351%28v=vs.110%29.aspx
            //                      https://msdn.microsoft.com/en-us/library/dd997402(v=vs.110).aspx
            // RabbitMQ message consumption: https://www.rabbitmq.com/dotnet-api-guide.html
        }

        public object GetMessageSenderFactory()
        {
            // TODO : This method will return a factory which will return a message sender per type. This type will receive a reference
            // to the MessageBusEngine (this) class. When a message is sent from this sender type the call will be proxied back to this class
            // where it will be routed to the correct queue...

            return _messageSenderFactory;
        }

        /// <summary>
        ///  Dispose all resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // We're not checking the disposing flag because we do not know whether the 'Dispose' method or the 'Finalizer' will execute first. We want 
            // the same behaviour regardless of which one fires first...

            // TODO : Dispose managed resources...
        }

        /// <summary>
        /// Finalizer to perform clean up when Dispose() is not explicitly called.
        /// </summary>
        ~MessageBusEngine()
        {
            Dispose(false);
        }
    }
}
