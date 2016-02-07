using AutoMapper;
using StructureMap;
using StructureMap.Graph;

namespace Common.Mapping.StructureMap.Registries
{
    public class MapperRegistry : 
        Registry
    {
        public MapperRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.AddAllTypesOf<IMappingConfiguration>();
                scanner.ConnectImplementationsToTypesClosing(typeof(ITypeMapper<,>));
                scanner.WithDefaultConventions();
            });

            For<IMapper>()
                .Use<MapperProxy>()
                .Singleton();
        }
    }
}
