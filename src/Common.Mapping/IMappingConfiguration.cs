using AutoMapper;

namespace Common.Mapping
{
    public interface IMappingConfiguration
    {
        void CreateMapping(IMapperConfiguration configuration);
    }
}
