namespace Hermes.Internal.Models.Contracts
{
    internal interface IMessageDefinition
    {
        string Type { get; set; }
        string Exchange { get; set; }
    }
}
