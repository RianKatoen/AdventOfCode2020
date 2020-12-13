using AdventOfCode2020.Traveling.Luggage;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day7
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
            var luggageProcessor = new LuggageProcessor();
            foreach (var rule in _input)
            {
                luggageProcessor.AddRule(rule);
            }

            var parentBags = luggageProcessor.FindParentBags("shiny gold");
            var noParentBags = parentBags.Count();

            _output.WriteLine($"Soluton: {noParentBags} type of bags can (in)directly contain a shiny gold bag.");
            Assert.Equal(332, noParentBags);
        }

        [Fact]
        public void Part2()
        {
            var luggageProcessor = new LuggageProcessor();
            foreach (var rule in _input)
            {
                luggageProcessor.AddRule(rule);
            }

            var totalNoBags = luggageProcessor.CountTotalBags("shiny gold");

            _output.WriteLine($"Soluton: {totalNoBags} type of bags can (in)directly contain a shiny gold bag.");
            Assert.Equal(10875, totalNoBags);
        }
    }
}
