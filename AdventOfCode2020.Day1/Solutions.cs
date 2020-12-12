using AdventOfCode2020.Expenses;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day1
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly int[] _report;
        private ReportGenerator _reportGenerator = new ReportGenerator();
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
            _report = File
                .ReadAllLines("Report.txt")
                .Select(l => int.Parse(l))
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = _reportGenerator.FindPair(_report, 2020);

            _output.WriteLine($"Solution: {result}");
            Assert.Equal(970816, result);
        }

        [Fact]
        public void Part2()
        {
            var result = _reportGenerator.FindTriplet(_report, 2020);

            _output.WriteLine($"Solution: {result}");
            Assert.Equal(96047280, result);
        }
    }
}
