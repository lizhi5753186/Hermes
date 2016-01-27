namespace Hermes.Contracts
{
    /// <summary>
    /// A message bus message contract. All messages to be sent over the message bus need to implement this interface.
    /// </summary>
    /// <typeparam name="T">Message to handle</typeparam>
    
    // TODO : T need to be of a specific type e.g. IMessage \ IEvent \ ICommand
    public interface IMessageHandler<in T>
        where T : class
    {
        void Handle(T message);
    }
}
