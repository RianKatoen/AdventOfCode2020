using AdventOfCode2020.Traveling.Boarding;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Boarding
{
    public class SeatLocatorTests
    {
        [Theory]
        [InlineData("FBFBFRLRR", -1, -1, -1)]
        [InlineData("FBFBBFFRLRR", -1, -1, -1)]
        [InlineData("FBFBBFFRFR", -1, -1, -1)]
        [InlineData("FBLBBFFRLR", -1, -1, -1)]
        [InlineData("FBLBBAFRLR", -1, -1, -1)]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void GetSeatInfo_Should_Work(string code, int row, int column, int id)
        {
            var sut = new SeatLocator();
            var info = sut.GetSeatInfo(code);

            Assert.Equal(row, info.Row);
            Assert.Equal(column, info.Column);
            Assert.Equal(id, info.Id);
        }
    }
}
