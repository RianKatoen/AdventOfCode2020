using AdventOfCode2020.Traveling.Trajectories;
using System;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Trajectories
{
    public class NavigatorTests
    {
        [Fact]
        public void Example()
        {
            var instructions = new string[]
            {
                "F10", "N3", "F7", "R90", "F11"
            };

            var sut = new Navigator();
            sut.Navigate(instructions);
            Assert.Equal(25, Math.Abs(sut.East) + Math.Abs(sut.North));
        }
    }
}
