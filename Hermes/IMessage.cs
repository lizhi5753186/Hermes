namespace Hermes
{
    /// <summary>
    /// Represent a message that can be put onto a service bus
    /// </summary>
    /// <typeparam name="T">Type of the message to be put onto a service bus</typeparam>
    public interface IMessage<T>
        where T : class 
    {
    }
}
