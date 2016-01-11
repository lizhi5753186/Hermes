using Hermes.Contracts;
using StructureMap;

namespace Hermes.Engine.Internal
{
    internal class MessageSenderFactory : IMessageSenderFactory
    {
        private readonly Container _messageTypeContainer;

        public MessageSenderFactory(Container messageTypeContainer)
        {
            _messageTypeContainer = messageTypeContainer;
        }

        public T GetMessageSender<T>() 
            where T : IMessage
        {
            return _messageTypeContainer.GetInstance<T>();
        }
    }
}
