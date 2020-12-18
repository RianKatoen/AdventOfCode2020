using AdventOfCode2020.Traveling.Trajectories;
using System;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Trajectories
{
    public class WaypointNavigatorTests
    {
        [Fact]
        public void Example()
        {
            var instructions = new string[]
            {
                "F10", "N3", "F7", "R90", "F11"
            };

            var sut = new WaypointNavigator();
            sut.Navigate(instructions);
            Assert.Equal(286, Math.Abs(sut.PositionEast) + Math.Abs(sut.PositionNorth));
        }
    }
}
