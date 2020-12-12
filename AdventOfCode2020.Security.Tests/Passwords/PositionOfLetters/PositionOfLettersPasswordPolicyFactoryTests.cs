using AdventOfCode2020.Security.Passwords.PositionOfLetters;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Passwords.PositionOfLetters
{
    public class PositionOfLettersPasswordPolicyFactoryTests
    {
        [Theory]
        [InlineData("1-3 a", 1, 3, 'a')]
        [InlineData("1-3 b", 1, 3, 'b')]
        [InlineData("2-9 c", 2, 9, 'c')]
        public void Create_Should_Work_PolicyString(string policy,
            int positionA, int positionB, char character)
        {
            var sut = new PositionOfLettersPasswordPolicyFactory();

            var result = sut.Create(policy);

            var passwordPolicy = Assert.IsType<PositionOfLettersPasswordPolicy>(result);

            Assert.Equal(positionA, passwordPolicy.PositionA);
            Assert.Equal(positionB, passwordPolicy.PositionB);
            Assert.Equal(character, passwordPolicy.Character);
        }
    }
}
