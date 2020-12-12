using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class HairColorPassportValidationRuleTests
    {

        [Theory]
        [InlineData("#123abc", true)]
        [InlineData("#123abz", false)]
        [InlineData("123abc", false)]
        [InlineData("#123ABC", false)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new HairColorPassportValidationRule();
            Assert.Equal("hcl", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

