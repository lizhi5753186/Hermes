using AutoMapper;
using Common.Mapping.Tests.MappingTestConfig.Models;
using NUnit.Framework;
using Shouldly;

namespace Common.Mapping.Tests
{
    [TestFixture]
    public class WhenValidMappingConfigurationsIsLoaded :
        CommonMappingTestBase

    {
        [OneTimeSetUp]
        public override void SetupScenario()
        {
            GivenValidMappingConfigurationMappings();
        }

        [Test]
        public void ThenAValidIMapperShouldBeResolvedFromTheContainer()
        {
            Container.GetInstance<IMapper>()
                .ShouldNotBeNull();
        }

        [Test]
        public void ThenASourceEntityMapperShouldBeInIocContainer()
        {
            Container.GetInstance<ITypeMapper<SourceEntity, TargetEntity>>()
                .ShouldNotBeNull();
        }
    }
}
