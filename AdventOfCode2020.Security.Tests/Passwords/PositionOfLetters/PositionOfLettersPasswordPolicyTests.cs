using AdventOfCode2020.Security.Passwords.PositionOfLetters;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Passwords.PositionOfLetters
{
    public class PositionOfLettersPasswordPolicyTests
    {
        [Theory]
        [InlineData(1, 3, 'a', "abcde", true)]
        [InlineData(1, 3, 'b', "cdefg", false)]
        [InlineData(2, 9, 'c', "ccccccccc", false)]
        public void PositionOfLettersPasswordPolicy_Should_Work(int positionA, int positionB, char character,
            string password, bool valid)
        {
            var sut = new PositionOfLettersPasswordPolicy(positionA, positionB, character);
            Assert.Equal(valid, sut.Verify(password));
        }
    }
}
