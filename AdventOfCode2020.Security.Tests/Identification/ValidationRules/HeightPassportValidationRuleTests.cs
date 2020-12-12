using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class HeightPassportValidationRuleTests
    {

        [Theory]
        [InlineData("58in", false)]
        [InlineData("59in", true)]
        [InlineData("60in", true)]
        [InlineData("69in", true)]
        [InlineData("75in", true)]
        [InlineData("76in", true)]
        [InlineData("77in", false)]
        [InlineData("149cm", false)]
        [InlineData("150cm", true)]
        [InlineData("151cm", true)]
        [InlineData("183cm", true)]
        [InlineData("192cm", true)]
        [InlineData("193cm", true)]
        [InlineData("194cm", false)]
        [InlineData("69", false)]
        [InlineData("190", false)]
        [InlineData("", false)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new HeightPassportValidationRule();
            Assert.Equal("hgt", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

