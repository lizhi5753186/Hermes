using Hermes.Contracts;
using StructureMap;

namespace Hermes.Internals
{
    internal class MessageSenderFactory : IMessageSenderFactory
    {
        private readonly Container _messageTypeContainer;

        public MessageSenderFactory(Container messageTypeContainer)
        {
            _messageTypeContainer = messageTypeContainer;
        }

        public T GetMessageSender<T>() 
            where T : class
        {
            return _messageTypeContainer.GetInstance<T>();
        }
    }
}
