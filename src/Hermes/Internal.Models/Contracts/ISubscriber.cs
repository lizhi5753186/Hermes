namespace Hermes.Internal.Models.Contracts
{
    internal interface ISubscriber :
        IMessageDefinition
    {
        IMessageConcurrency Concurrency { get; set; }
    }
}