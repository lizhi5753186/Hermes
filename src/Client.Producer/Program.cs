using System;
using System.Diagnostics;
using Hermes.Engine;

namespace Client.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBusHost.ShuttingDown += MessageBusHost_ShuttingDown;
            MessageBusHost.ShutdownCompleted += MessageBusHost_ShutdownCompleted;

            MessageBusHost
                .GetEngine()
                .Start();
        }

        private static void MessageBusHost_ShuttingDown(object sender, Hermes.Contracts.IMessageBusEngine e)
        {
            Debug.WriteLine("Shutting down");
        }

        private static void MessageBusHost_ShutdownCompleted(object sender, Hermes.Contracts.IMessageBusEngine e)
        {
            Debug.WriteLine("Shutdown completed");
        }
    }
}
