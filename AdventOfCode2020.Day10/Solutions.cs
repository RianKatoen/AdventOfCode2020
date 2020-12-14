using AdventOfCode2020.Traveling.Adapters;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day10
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly int[] _input = File.ReadAllLines("Input.txt").Select(i => int.Parse(i)).ToArray();
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var joltageChain = new JoltageChain(_input);
            var answer = joltageChain.NoJoltageDeltas(1) * joltageChain.NoJoltageDeltas(3);

            _output.WriteLine($"Soluton: {answer}");
            Assert.Equal(2059, answer);
        }

        [Fact]
        public void Part2()
        {
            var joltageChain = new JoltageChain(_input);
            var noDistinctChains = joltageChain.NoDistinctChains();

            _output.WriteLine($"Soluton: {noDistinctChains}");
            Assert.Equal(86812553324672, noDistinctChains);
        }
    }
}
