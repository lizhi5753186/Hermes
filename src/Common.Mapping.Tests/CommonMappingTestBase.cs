using StructureMap;
using StructureMap.Graph;

namespace Common.Mapping.Tests
{
    public abstract class CommonMappingTestBase
    {
        protected IContainer Container;

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
    }
}
