namespace Hermes.Contracts
{
    public interface IDataContract
    {
        string Name { get; set; }
        string LastName { get; set; }

        string GetName();
    }
}
