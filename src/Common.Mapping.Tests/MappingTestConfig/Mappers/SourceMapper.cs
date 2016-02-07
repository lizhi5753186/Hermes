using AutoMapper;
using Common.Mapping.Tests.MappingTestConfig.Models;

namespace Common.Mapping.Tests.MappingTestConfig.Mappers
{
    public class SourceMapper : 
        ITypeMapper<SourceEntity, TargetEntity>
    {
        private readonly IMapper _mapper;

        public SourceMapper(
            IMapper mapper
            )
        {
            _mapper = mapper;
        }

        public TargetEntity Map(SourceEntity @from)
        {
            return _mapper.Map<TargetEntity>(@from);
        }
    }
}
