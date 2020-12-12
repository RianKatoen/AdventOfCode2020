using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class IssueYearPassportValidationRuleTests
    {

        [Theory]
        [InlineData("58", false)]
        [InlineData("599", false)]
        [InlineData("2009", false)]
        [InlineData("2010", true)]
        [InlineData("2011", true)]
        [InlineData("2015", true)]
        [InlineData("2019", true)]
        [InlineData("2020", true)]
        [InlineData("2021", false)]
        [InlineData(" 2015 ", false)]
        [InlineData("2015 ", false)]
        [InlineData(" 2015", false)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new IssueYearPassportValidationRule();
            Assert.Equal("iyr", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

