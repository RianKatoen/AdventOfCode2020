using AdventOfCode2020.Security.Passwords.NumberOfLetters;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Passwords.NumberOfLetters
{
    public class NumberOfLettersPasswordPolicyTests
    {
        [Theory]
        [InlineData(1, 3, 'a', "abcde", true)]
        [InlineData(1, 3, 'b', "cdefg", false)]
        [InlineData(2, 9, 'c', "ccccccccc", true)]
        public void NumberOfLettersPasswordPolicy_Should_Work(int minTimes, int maxTimes, char character,
            string password, bool valid)
        {
            var sut = new NumberOfLettersPasswordPolicy(minTimes, maxTimes, character);
            Assert.Equal(valid, sut.Verify(password));
        }
    }
}
