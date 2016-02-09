using NUnit.Framework;
using Shouldly;

namespace Common.Mapping.Tests
{
    [TestFixture]
    public class WhenMappingIsDone :
        CommonMappingTestBase
    {
        [OneTimeSetUp]
        public override void SetupScenario()
        {
            GivenValidMappingConfigurationMappings();
            GivenAValidSourceObject();
            GivenMappingFromSourceToTargetWasDone();
        }

        [Test]
        public void ThenTargetShouldEqualSource()
        {
            Target.ShouldSatisfyAllConditions(
                () => Target.Name.ShouldBe(Source.Name),
                () => Target.LastName.ShouldBe(Source.LastName)
                );
        }

        [Test]
        public void ThenCustomFieldMappingShouldBeMapped()
        {
            Target.TargetAge
                .ShouldBe(Source.Age);
        }
    }
}
