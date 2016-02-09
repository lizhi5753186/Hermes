using Common.Mapping.Tests.MappingTestConfig.Models;
using StructureMap;
using StructureMap.Graph;

namespace Common.Mapping.Tests
{
    public abstract class CommonMappingTestBase
    {
        protected IContainer Container;
        protected SourceEntity Source;
        protected TargetEntity Target;

        public abstract void SetupScenario();

        protected void GivenValidMappingConfigurationMappings()
        {
            Container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssembliesFromApplicationBaseDirectory();
                    scanner.LookForRegistries();
                });
            });
        }

        protected void GivenAValidSourceObject()
        {
            Source = new SourceEntity()
            {
                Name = "TestName",
                LastName = "TestLastname",
                Age = 35
            };
        }

        protected void GivenMappingFromSourceToTargetWasDone()
        {
            var mapper = Container.GetInstance<ITypeMapper<SourceEntity, TargetEntity>>();
            Target = mapper.Map(Source);
        }
    }
}
