using Hermes.Contracts;
using StructureMap;
using StructureMap.Graph;
using System;

namespace Hermes.Engine
{
    /// <summary>
    /// A class representing a Hermes message bus engine.
    /// </summary>
    public class MessageBusEngine : IDisposable
    {
        private Container _container = null;

        /// <summary>
        /// Bootstraps and starts the Hermes message bus engine.
        /// </summary>
        public MessageBusEngine Initialize()
        {
            // Setup internal container. This container will be used to resolve implementations of the IMessageHandler interface...
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

            // TODO : Read and parse custom config sections in config files...
            // TODO : Bootstrap RabbitMQ Client...

            return this;
        }

        /// <summary>
        /// Starts the Hermes message bus engine.
        /// </summary>
        public void Start()
        {

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
            if (disposing)
            {
                // Dispose managed resources...
            }
        }
    }
}
