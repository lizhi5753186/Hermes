using Hermes.Contracts;

namespace Client.Messages
{
    public class Message : IMessage
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
