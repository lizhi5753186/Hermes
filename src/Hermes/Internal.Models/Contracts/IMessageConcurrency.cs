namespace Hermes.Internal.Models.Contracts
{
    internal interface IMessageConcurrency
    {
        int Count { get; set; }
    }
}