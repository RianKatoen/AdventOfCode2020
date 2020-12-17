using AdventOfCode2020.Traveling.Waiting;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Waiting
{
    public class SeatTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Seat_Should_Stay_Empty(int noSeats)
        {
            var neigbouringSeats = new List<Seat>
            {
                new Seat(SeatState.Occupied),
                new Seat(SeatState.Empty),
                new Seat(SeatState.Empty),
            };

            var seat = new Seat(SeatState.Empty, neigbouringSeats.Take(noSeats));

            Assert.Equal(0, seat.CalculateNextState());
            seat.ApplyNextState();
            Assert.Equal(SeatState.Empty, seat.State);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Seat_Should_Become_Occupied(int noSeats)
        {
            var neigbouringSeats = new List<Seat>
            {
                new Seat(SeatState.Empty),
                new Seat(SeatState.Empty),
                new Seat(SeatState.Empty),
                new Seat(SeatState.Empty)
            };

            var seat = new Seat(SeatState.Empty, neigbouringSeats.Take(noSeats));

            Assert.Equal(1, seat.CalculateNextState());
            seat.ApplyNextState();
            Assert.Equal(SeatState.Occupied, seat.State);
        }
    }
}
