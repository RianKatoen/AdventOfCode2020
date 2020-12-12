using AdventOfCode2020.Security.Passwords.NumberOfLetters;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Passwords.NumberOfLetters
{
    public class NumberOfLettersPasswordPolicyFactoryTests
    {
        [Theory]
        [InlineData("1-3 a", 1, 3, 'a')]
        [InlineData("1-3 b: cdefg", 1, 3, 'b')]
        [InlineData("dwadwa 2-9 c: cdefg", 2, 9, 'c')]
        public void Create_Should_Work_PolicyString(string policy,
            int minTimes, int maxTimes, char character)
        {
            var sut = new NumberOfLettersPasswordPolicyFactory();

            var result = sut.Create(policy);
            var passwordPolicy = Assert.IsType<NumberOfLettersPasswordPolicy>(result);

            Assert.Equal(minTimes, passwordPolicy.MinTimes);
            Assert.Equal(maxTimes, passwordPolicy.MaxTimes);
            Assert.Equal(character, passwordPolicy.Character);
        }
    }
}
