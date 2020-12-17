using AdventOfCode2020.Traveling.Waiting;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day11
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly string[] _input = File.ReadAllLines("Input.txt").ToArray();
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var layout = new SeatLayout(_input);
            while (layout.Tick() > 0) ;
            var answer = layout.NoOccupiedSeats();

            _output.WriteLine($"Soluton: {answer}");
            Assert.Equal(2283, answer);
        }

        [Fact]
        public void Part2()
        {
            var layout = new SeatLayout(_input, true);
            while (layout.Tick() > 0) ;
            var answer = layout.NoOccupiedSeats();

            _output.WriteLine($"Soluton: {answer}");
            Assert.Equal(2054, answer);
        }
    }
}
