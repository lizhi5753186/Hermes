using System;
using System.Reflection;
using System.Threading;
using Hermes.Contracts;
using Hermes.UnitTest.Helpers;

namespace Hermes.Tests.Engine.MessageBusHost
{
    public abstract class MessageBusHostTestBase : MarshalByRefObject
    {
        protected IMessageBusEngine MessageBusEngine;
        protected IMessageBusEngine SecondMessageBusEngine;
        protected CancellationToken CreatedCancellationToken;
        protected CancellationToken SecondCreatedCancellationToken;
        protected bool IsHostAndEngineShutdown = false;

        protected void GivenSuccesfulEngineRetrieval()
        {
            GetMessageBusEngine();
        }

        protected void GivenAnEngineWasPreviouslyRetrieved()
        {
            GetMessageBusEngine();
            GetSecondMessageBusEngine();
        }

        protected void GivenTheMessageBusHostAppDomainIsUnloaded()
        {
            var appDomain = AppDomain.CreateDomain("MessageBusHost.Domain");

            var assemblyLocation = Assembly
                .GetCallingAssembly()
                .Location
                .Replace(
                    ".Tests",
                    string.Empty
                );

            var assembly = Assembly.Load(
                AssemblyName
                    .GetAssemblyName(
                        assemblyLocation
                    )
                );

            var hostProxy = (MessageBusHostProxy)appDomain
                .CreateInstanceFromAndUnwrap(
                    assembly.Location,
                    "Hermes.UnitTest.Helpers.MessageBusHostProxy"
                );

            // This subscription fails... will have to look into this a little more...
            hostProxy.ShutdownCompleted += HostProxy_ShutdownCompleted;

            AppDomain.Unload(appDomain);
        }

        private Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return args.RequestingAssembly;
        }

        private void HostProxy_ShutdownCompleted(object sender, IMessageBusEngine e)
        {
            IsHostAndEngineShutdown = true;
        }

        private void GetMessageBusEngine()
        {
            MessageBusEngine = Hermes.Engine
                .MessageBusHost
                .GetEngine();

            CreatedCancellationToken = MessageBusEngine.CancellationToken;
        }

        private void GetSecondMessageBusEngine()
        {
            SecondMessageBusEngine = Hermes.Engine
                .MessageBusHost
                .GetEngine();

            SecondCreatedCancellationToken = MessageBusEngine.CancellationToken;
        }
    }
}
