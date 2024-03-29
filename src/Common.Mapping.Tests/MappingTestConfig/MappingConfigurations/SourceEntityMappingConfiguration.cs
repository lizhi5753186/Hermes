﻿using AutoMapper;
using Common.Mapping.Tests.MappingTestConfig.Models;

namespace Common.Mapping.Tests.MappingTestConfig.MappingConfigurations
{
    public class SourceEntityMappingConfiguration :
        IMappingConfiguration
    {
        public void CreateMapping(IMapperConfiguration configuration)
        {
            configuration.CreateMap<SourceEntity, TargetEntity>()
                .ForMember(
                    dest => dest.TargetAge,
                    opts => opts.MapFrom(src => src.Age)
                );
        }
    }
}
