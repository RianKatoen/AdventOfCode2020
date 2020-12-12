using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class ExpirationYearPassportValidationRuleTests
    {

        [Theory]
        [InlineData("58", false)]
        [InlineData("599", false)]
        [InlineData("2019", false)]
        [InlineData("2020", true)]
        [InlineData("2021", true)]
        [InlineData("2025", true)]
        [InlineData("2029", true)]
        [InlineData("2030", true)]
        [InlineData("2031", false)]
        [InlineData(" 2025 ", false)]
        [InlineData("2025 ", false)]
        [InlineData(" 2025", false)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new ExpirationYearPassportValidationRule();
            Assert.Equal("eyr", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

