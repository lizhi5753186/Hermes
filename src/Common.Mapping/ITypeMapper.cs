namespace Common.Mapping
{
    public interface ITypeMapper<in TFrom, out TTo>
        where TFrom : class
        where TTo : class
    {
        TTo Map(TFrom from);
    }
}
