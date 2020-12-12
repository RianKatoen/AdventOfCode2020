using AdventOfCode2020.Traveling.Boarding;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day5
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
            var seatLocator = new SeatLocator();
            var maxId = _input.Select(l => seatLocator.GetSeatInfo(l).Id).Max();

            _output.WriteLine($"Soluton: {maxId} is highed seat ID.");
            Assert.Equal(888, maxId);
        }

        [Fact]
        public void Part2()
        {
            var seatLocator = new SeatLocator();
            var ids = _input
                .Select(l => seatLocator.GetSeatInfo(l).Id)
                .OrderBy(id => id)
                .ToArray();

            var maxId = 0;
            for (var i = 1; i < ids.Length; i++)
            {
                if (ids[i] - ids[i - 1] == 2)
                {
                    maxId = ids[i - 1] + 1;
                    _output.WriteLine($"Solution: {maxId} is the last available chair.");
                    Assert.Equal(522, maxId);
                    return;
                }
            }

            Assert.True(maxId > 0);
        }
    }
}
