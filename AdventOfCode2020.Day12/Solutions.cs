using AdventOfCode2020.Traveling.Trajectories;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day12
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
            var navigator = new Navigator();
            navigator.Navigate(_input);

            var manhattanDistance = Math.Abs(navigator.East) + Math.Abs(navigator.North);
            _output.WriteLine($"Soluton: {manhattanDistance}");
            Assert.Equal(1533, manhattanDistance);
        }

        [Fact]
        public void Part2()
        {
            var navigator = new WaypointNavigator();
            navigator.Navigate(_input);

            var manhattanDistance = Math.Abs(navigator.PositionNorth) + Math.Abs(navigator.PositionEast);
            _output.WriteLine($"Soluton: {manhattanDistance}");
            Assert.Equal(25235, manhattanDistance);
        }
    }
}
