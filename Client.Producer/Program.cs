using Hermes.Engine;

namespace Client.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBusHost
                .GetEngine()
                .Initialize()
                .Start();
        }
    }
}
