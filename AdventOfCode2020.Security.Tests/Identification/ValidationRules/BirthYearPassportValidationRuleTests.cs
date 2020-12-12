using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class BirthYearPassportValidationRuleTests
    {

        [Theory]
        [InlineData("58", false)]
        [InlineData("599", false)]
        [InlineData("1919", false)]
        [InlineData("1920", true)]
        [InlineData("1921", true)]
        [InlineData("1999", true)]
        [InlineData("2001", true)]
        [InlineData("2002", true)]
        [InlineData("2003", false)]
        [InlineData(" 1999 ", false)]
        [InlineData("1999 ", false)]
        [InlineData(" 1999", false)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new BirthYearPassportValidationRule();
            Assert.Equal("byr", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

