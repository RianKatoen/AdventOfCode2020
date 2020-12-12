using AdventOfCode2020.Traveling.Maps;
using AdventOfCode2020.Traveling.Trajectories;
using System.IO;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Trajectories
{
    public class TrajectoryCalculatorTests
    {
        private readonly Map _map = new Map(File.ReadAllLines("Maps/Example.txt"));

        [Fact]
        public void NoTree_Should_Work()
        {
            var sut = new TrajectoryCalculator();
            Assert.Equal(7, sut.NumberOfTrees(_map, 3, 1));
        }
    }
}
