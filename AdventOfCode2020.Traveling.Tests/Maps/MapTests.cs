using AdventOfCode2020.Traveling.Maps;
using System.IO;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Maps
{
    public class MapTests
    {
        private readonly Map _map = new Map(File.ReadAllLines("Maps/Example.txt"));

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(1, 0, false)]
        [InlineData(2, 0, true)]
        [InlineData(12, 0, false)]
        [InlineData(13, 0, true)]
        [InlineData(0, 3, false)]
        [InlineData(2, 3, true)]
        [InlineData(10, 3, true)]
        [InlineData(11, 10, false)]
        [InlineData(12, 10, true)]
        public void Tree_Should_Work(int x, int y, bool expected)
        {
            Assert.Equal(expected, _map.IsTree(x, y));
        }
    }
}
