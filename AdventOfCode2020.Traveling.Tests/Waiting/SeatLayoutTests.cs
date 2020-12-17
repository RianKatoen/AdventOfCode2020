using AdventOfCode2020.Traveling.Waiting;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Waiting
{
    public class SeatLayoutTests
    {
        [Fact]
        public void Example1()
        {
            var data = new string[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };

            var sut = new SeatLayout(data);

            var noTicks = 0;
            while (sut.Tick() > 0)
            {
                noTicks++;
            }

            Assert.Equal(37, sut.NoOccupiedSeats());
        }

        [Fact]
        public void Example2_Empty()
        {
            var data = new string[]
            {
                ".##.##.",
                "#.#.#.#",
                "##...##",
                "...L...",
                "##...##",
                "#.#.#.#",
                ".##.##."
            };

            var sut = new SeatLayout(data, true);
            Assert.Empty(sut[3, 3].NeighbouringSeats);
        }

        [Fact]
        public void Example2_EightNeighbouringSeats()
        {
            var data = new string[]
            {
                ".......#.",
                "...#.....",
                ".#.......",
                ".........",
                "..#L....#",
                "....#....",
                ".........",
                "#........",
                "...#....."
            };

            var sut = new SeatLayout(data, true);
            Assert.Equal(8, sut[4, 3].NeighbouringSeats.Count);
        }

        [Fact]
        public void Example2()
        {
            var data = new string[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };

            var sut = new SeatLayout(data, true);

            var noTicks = 0;
            while (sut.Tick() > 0)
            {
                noTicks++;
            }

            Assert.Equal(26, sut.NoOccupiedSeats());
        }
    }
}
