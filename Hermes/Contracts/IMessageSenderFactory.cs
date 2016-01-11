namespace Hermes.Contracts
{
    public interface IMessageSenderFactory
    {
        T GetMessageSender<T>()
            where T : IMessage;
    }
}
