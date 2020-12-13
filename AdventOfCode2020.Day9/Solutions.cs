using AdventOfCode2020.Security.Encryption;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day9
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly long[] _input = File.ReadAllLines("Input.txt").Select(i => long.Parse(i)).ToArray();
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var xmas = new Xmas(25, _input);
            var firstInvalidEntry = xmas.InvalidEntries().First();

            _output.WriteLine($"Soluton: {firstInvalidEntry}");
            Assert.Equal(1721308972, firstInvalidEntry);
        }

        [Fact]
        public void Part2()
        {
            var xmas = new Xmas(25, _input);
            var contiguousRange = xmas.ContiguousRanges(1721308972).First();
            var weakness = contiguousRange.Min() + contiguousRange.Max();

            _output.WriteLine($"Soluton: {weakness}");
            Assert.Equal(209694133, weakness);
        }
    }
}
