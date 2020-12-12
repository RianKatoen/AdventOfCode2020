using AdventOfCode2020.Security.Identification.ValidationRules;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification.ValidationRules
{
    public class PassportIdPassportValidationRuleTests
    {

        [Theory]
        [InlineData("000000000", true)]
        [InlineData("000000001", true)]
        [InlineData("999999999", true)]
        [InlineData("00000001", false)]
        [InlineData("99999999", false)]
        [InlineData("0000000001", false)]
        [InlineData("9999999999", false)]
        public void Validate_ShouldWork(string value, bool valid)
        {
            var sut = new PassportIdPassportValidationRule();
            Assert.Equal("pid", sut.PropertyName);
            Assert.Equal(valid, sut.Validate(value));
        }
    }
}

