using AdventOfCode2020.Security.Identification;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Identification
{
    public class PassportScannerTests
    {
        [Fact]
        public void GetFields_ShouldWork()
        {
            var data = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var sut = new PassportScanner();

            var fields = sut.GetFields(data);

            Assert.Equal(8, fields.Count);
        }

        [Theory]
        [InlineData(1, "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm", true)]
        [InlineData(2, "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929", false)]
        [InlineData(3, "hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm", true)]
        [InlineData(4, "hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in", false)]
        public void ValidPassport_ShouldWork(int _, string document, bool valid)
        {
            var sut = new PassportScanner();

            var fields = sut.GetFields(document);

            Assert.Equal(valid, sut.ValidPassport(fields));
        }

        [Fact]
        public void Example_ShouldWork()
        {
            var data = File.ReadAllLines("Identification/Example.txt");
            var sut = new PassportScanner();
            var passports = sut.ParseData(data).ToList();

            Assert.Equal(4, passports.Count);
            Assert.Equal("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm", passports[0]);
            Assert.Equal("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929", passports[1]);
            Assert.Equal("hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm", passports[2]);
            Assert.Equal("hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in", passports[3]);
        }
    }
}

