using AdventOfCode2020.Navigation.Maps;
using AdventOfCode2020.Navigation.Trajectories;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day3
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly Map _map = new Map(File.ReadAllLines("Input.txt"));
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var trajectoryCalculator = new TrajectoryCalculator();
            var noTrees = trajectoryCalculator.NumberOfTrees(_map, 3, 1);

            _output.WriteLine($"Solution: {noTrees} trees passed.");
            Assert.Equal(195, noTrees);
        }

        [Fact]
        public void Part2()
        {
            var trajectoryCalculator = new TrajectoryCalculator();

            long product = 1;
            product *= trajectoryCalculator.NumberOfTrees(_map, 1, 1);
            product *= trajectoryCalculator.NumberOfTrees(_map, 3, 1);
            product *= trajectoryCalculator.NumberOfTrees(_map, 5, 1);
            product *= trajectoryCalculator.NumberOfTrees(_map, 7, 1);
            product *= trajectoryCalculator.NumberOfTrees(_map, 1, 2);

            _output.WriteLine($"Solution: {product}");
            Assert.Equal(3_772_314_000, product);
        }
    }
}
