using Hermes.Contracts;

namespace Client.Producer
{
    public class Message : IMessage
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
