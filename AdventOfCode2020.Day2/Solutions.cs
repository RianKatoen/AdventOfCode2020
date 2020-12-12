using AdventOfCode2020.Security.Passwords;
using AdventOfCode2020.Security.Passwords.NumberOfLetters;
using AdventOfCode2020.Security.Passwords.PositionOfLetters;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day2
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly string[] _passwordsData;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
            _passwordsData = File
                .ReadAllLines("Passwords.txt")
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var policyFactory = new NumberOfLettersPasswordPolicyFactory();
            var counter = new ValidPasswordCounter(policyFactory);
            var noValidPasswords = counter.Count(_passwordsData);

            _output.WriteLine($"Solution: {noValidPasswords} passwords are valid.");
            Assert.Equal(591, noValidPasswords);
        }

        [Fact]
        public void Part2()
        {
            var policyFactory = new PositionOfLettersPasswordPolicyFactory();
            var counter = new ValidPasswordCounter(policyFactory);
            var noValidPasswords = counter.Count(_passwordsData);

            _output.WriteLine($"Solution: {noValidPasswords} passwords are valid.");
            Assert.Equal(335, noValidPasswords);
        }
    }
}
