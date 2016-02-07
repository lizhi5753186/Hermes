using AutoMapper;
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
    }
}
