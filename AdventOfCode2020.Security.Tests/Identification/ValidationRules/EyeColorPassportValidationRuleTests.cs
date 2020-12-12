using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class EyeColorPassportValidationRuleTests
    {

        [Theory]
        [InlineData("amb", true)]
        [InlineData("blu", true)]
        [InlineData("brn", true)]
        [InlineData("gry", true)]
        [InlineData("grn", true)]
        [InlineData("hzl", true)]
        [InlineData("oth", true)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new EyeColorPassportValidationRule();
            Assert.Equal("ecl", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

