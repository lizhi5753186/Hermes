using System;
using System.Collections.Generic;
using AutoMapper;
using StructureMap;

namespace Common.Mapping
{
    /// <summary>
    /// A wrapper around AutoMapper to abstract a specific mapper from the consuming code. The way this wrapper and the supporting classes work
    /// will add a little more semantics around the mappers being injected into classes.
    /// </summary>
    public class MapperProxy : 
        IMapper
    {
        private readonly IEnumerable<IMappingConfiguration> _mappingConfigurations;
        private readonly IMapper _mapper;

        public MapperProxy(
            IContainer container
            )
        {
            _mappingConfigurations = container.GetAllInstances<IMappingConfiguration>();

            var config = new MapperConfiguration(
                cfg =>
                {
                    foreach (var mappingconfig in _mappingConfigurations)
                    {
                        mappingconfig.CreateMapping(cfg);
                    }
                });

            _mapper = config.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider
            => _mapper.ConfigurationProvider;

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            return _mapper.Map<TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return _mapper.Map<TSource, TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return _mapper.Map<TSource, TDestination>(source, destination, opts);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return _mapper.Map(source, sourceType, destinationType, opts);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, destination, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return _mapper.Map(source, destination, sourceType, destinationType, opts);
        }
    }
}
