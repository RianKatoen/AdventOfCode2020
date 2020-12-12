using AdventOfCode2020.Security.Identification;
using AdventOfCode2020.Security.Identification.ValidationRules;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day4
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly string[] _input = File.ReadAllLines("Input.txt");
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var passportScanner = new PassportScanner();
            var noValidPassports = passportScanner
                .ParseData(_input)
                .Where(i => passportScanner.ValidPassport(passportScanner.GetFields(i)))
                .Count();

            _output.WriteLine($"Solution: {noValidPassports} valid passports.");
            Assert.Equal(247, noValidPassports);
        }

        [Fact]
        public void Part2()
        {
            var passportScanner = new PassportScanner();
            var rules = new List<IPassportValidationRule>
            {
                new BirthYearPassportValidationRule(),
                new ExpirationYearPassportValidationRule(),
                new EyeColorPassportValidationRule(),
                new HairColorPassportValidationRule(),
                new HeightPassportValidationRule(),
                new IssueYearPassportValidationRule(),
                new PassportIdPassportValidationRule()
            };

            var noValidPassports = passportScanner
                .ParseData(_input)
                .Where(i => passportScanner.ValidPassport(rules, passportScanner.GetFields(i)))
                .Count();

            _output.WriteLine($"Solution: {noValidPassports} valid passports.");
            //Assert.Equal(247, noValidPassports);
        }
    }
}
